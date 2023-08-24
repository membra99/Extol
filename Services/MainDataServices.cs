﻿using AutoMapper;
using Entities.Context;
using Entities.Migrations;
using Entities.Universal.MainData;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NetTopologySuite.Index.HPRtree;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Universal.DTO.IDTO;
using Universal.DTO.ODTO;

namespace Services
{
    public class MainDataServices : BaseServices
    {
        public static UsersServices _userServices;

        public MainDataServices(MainContext context, IMapper mapper, UsersServices usersServices) : base(context, mapper)
        {
            _userServices = usersServices;
        }

        public List<ChildODTO> children = new List<ChildODTO>();
        private int i = 0;

        #region Categories

        private IQueryable<CategoriesODTO> GetCategories(int id)
        {
            return from x in _context.Categories
                   where (id == 0 || x.CategoryId == id)
                   select _mapper.Map<CategoriesODTO>(x);
        }

        public async Task<CategoriesODTO> GetCategoriesById(int id)
        {
            return await GetCategories(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<CategoriesODTO> AddCategory(CategoriesIDTO categoriesIDTO)
        {
            int seo = 0;
            if (categoriesIDTO.SeoIDTO.GoogleKeywords != null || categoriesIDTO.SeoIDTO.GoogleKeywords != null)
            {
                seo = await AddSeo(categoriesIDTO.SeoIDTO.GoogleDesc, categoriesIDTO.SeoIDTO.GoogleKeywords);
            }

            var categories = _mapper.Map<Categories>(categoriesIDTO);
            categories.CategoryId = 0;
            categories.SeoId = (seo != 0) ? seo : null;
            _context.Categories.Add(categories);

            await SaveContextChangesAsync();

            return await GetCategoriesById(categories.CategoryId);
        }

        public async Task<CategoriesODTO> EditCategory(CategoriesIDTO categoriesIDTO)
        {
            var categories = _mapper.Map<Categories>(categoriesIDTO);
            _context.Entry(categories).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetCategoriesById(categories.CategoryId);
        }

        public async Task<CategoriesODTO> DeleteCategory(int id)
        {
            var categories = await _context.Categories.FindAsync(id);
            if (categories == null) return null;

            var prodAttr = await _context.ProductAttributes.Where(x => x.CategoriesId == categories.CategoryId).ToListAsync();
            foreach (var item in prodAttr)
            {
                _context.ProductAttributes.Remove(item);
                await SaveContextChangesAsync();
            }

            var prod = await _context.Products.Where(x => x.CategoriesId == categories.CategoryId).ToListAsync();
            foreach (var item in prod)
            {
                _context.Products.Remove(item);
                await SaveContextChangesAsync();
            }
            var categoriesODTO = await GetCategoriesById(id);

            categories.IsActive = false;
            _context.Entry(categories).State = EntityState.Modified;
            await SaveContextChangesAsync();
            return categoriesODTO;
        }

        #endregion Categories

        #region Product

        private IQueryable<ProductODTO> GetProducts(int id)
        {
            return from x in _context.Products
                   where (id == 0 || x.ProductId == id)
                   select _mapper.Map<ProductODTO>(x);
        }

        public async Task<ProductODTO> GetProductsById(int id)
        {
            return await GetProducts(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<ProductODTO>> GetAllProducts()
        {
            return await GetProducts(0).AsNoTracking().ToListAsync();
        }

        public async Task<ProductODTO> AddProduct(ProductIDTO productIDTO)
        {
            int seo = 0;
            if (productIDTO.SeoIDTO.GoogleKeywords != null || productIDTO.SeoIDTO.GoogleKeywords != null)
            {
                seo = await AddSeo(productIDTO.SeoIDTO.GoogleDesc, productIDTO.SeoIDTO.GoogleKeywords);
            }

            var product = _mapper.Map<Product>(productIDTO);
            product.ProductId = 0;
            product.SeoId = (seo != 0) ? seo : null;
            _context.Products.Add(product);

            await SaveContextChangesAsync();

            if (product.IsOnSale == true)
            {
                SaleIDTO sale = new SaleIDTO();
                sale.Value = productIDTO.SaleIDTO.Value;
                sale.SaleTypeId = productIDTO.SaleIDTO.SaleTypeId;
                sale.StartDate = productIDTO.SaleIDTO.StartDate;
                sale.EndDate = productIDTO.SaleIDTO.EndDate;
                sale.IsActive = true;
                sale.ProductId = product.ProductId;

                var SaleForDB = _mapper.Map<Sale>(sale);

                _context.Sales.Add(SaleForDB);

                await SaveContextChangesAsync();
            }

            return await GetProductsById(product.ProductId);
        }

        public async Task<int> AddSeo(string googleDesc, string googleKeywords)
        {
            Entities.Universal.MainData.Seo seo = new Entities.Universal.MainData.Seo();
            seo.SeoId = 0;
            seo.GoogleDesc = googleDesc;
            seo.GoogleKeywords = googleKeywords;
            _context.Seos.Add(seo);
            await SaveContextChangesAsync();

            return await (from x in _context.Seos
                          where x.SeoId == seo.SeoId
                          select x.SeoId).SingleOrDefaultAsync();
        }

        public async Task<ParentChildODTO> GetTree(int Id)
        {
            ParentChildODTO retval = new ParentChildODTO();
            var parentCategoryID = await _context.Categories.Where(x => x.CategoryId == Id).Select(x => x.ParentCategoryId).SingleOrDefaultAsync();
            bool notRoot = true;
            List<ParentODTO> parents = new List<ParentODTO>();
            while (notRoot)
            {
                ParentODTO parent = new ParentODTO();
                var currentCategories = await _context.Categories.Where(x => x.CategoryId == parentCategoryID).SingleOrDefaultAsync();
                parent.CategoryId = currentCategories.CategoryId;
                parent.IsRoot = (currentCategories.ParentCategoryId == null) ? true : false;
                parents.Add(parent);
                parentCategoryID = currentCategories.ParentCategoryId;
                if (currentCategories.ParentCategoryId == null)
                {
                    notRoot = false;
                }
            }

            retval.ParentCategory = parents;
            retval.ChildCategory = ReturnChildren(Id);

            return retval;
        }

        public List<ChildODTO> ReturnChildren(int Id)
        {
            var categoryList = _context.Categories.Where(x => x.ParentCategoryId == Id).ToList();
            foreach (var item in categoryList)
            {
                ChildODTO child = new ChildODTO();
                child.CategoryId = item.CategoryId;
                child.IsAttribute = item.IsAttribute;
                child.ParentCategoryId = item.ParentCategoryId;
                if (child.IsAttribute == true)
                {
                    var val = _context.ProductAttributes.Where(x => x.CategoriesId == child.CategoryId).Select(x => x.Value).ToList();
                    child.Values = val;
                    child.ParentCategoryId = Id;
                }
                children.Add(child);
            }
            if (children.Count() > i)
            {
                ReturnChildren(children[i++].CategoryId);
            }

            return children;
        }

        public async Task<ProductODTO> EditProduct(ProductIDTO productIDTO)
        {
            var product = _mapper.Map<Product>(productIDTO);
            _context.Entry(product).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetProductsById(product.ProductId);
        }

        public async Task<ProductODTO> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            var productODTO = await GetProductsById(id);

            var prodAttr = await _context.ProductAttributes.Where(x => x.ProductId == product.ProductId).ToListAsync();
            foreach (var item in prodAttr)
            {
                _context.ProductAttributes.Remove(item);
            }

            _context.Products.Remove(product);
            await SaveContextChangesAsync();

            return productODTO;
        }

        public async Task<List<ChildODTO2>> GetCategory()
        {
            var categoriesRoot = await _context.Categories.Where(x => x.ParentCategoryId == null).SingleOrDefaultAsync();

            var cat = ReturnChildren(categoriesRoot.CategoryId);

            ChildODTO child = new ChildODTO();
            child.CategoryId = categoriesRoot.CategoryId;
            child.IsAttribute = false;
            child.ParentCategoryId = categoriesRoot.ParentCategoryId;
            child.Values = null;
            cat.Insert(0, child);
            var CategoryWithoutAttr = (from y in cat
                                       where y.IsAttribute == false
                                       select y).ToList();
            List<ChildODTO2> children = new List<ChildODTO2>();
            foreach (var item in CategoryWithoutAttr)
            {
                ChildODTO2 ch = new ChildODTO2();
                ch.CategoryId = item.CategoryId;
                ch.ParentCategoryId = item.ParentCategoryId;
                ch.CategoryName = _context.Categories.Where(x => x.CategoryId == item.CategoryId).Select(x => x.CategoryName).SingleOrDefault();
                children.Add(ch);
            }

            return children;
        }

        public async Task<List<AttributeODTO>> GetAttribute(int CategoryId)
        {
            List<AttributeODTO> category = await (from x in _context.Categories
                                                  where x.ParentCategoryId == CategoryId
                                                  select new AttributeODTO
                                                  {
                                                      CategoryId = x.CategoryId,
                                                      CategoryName = x.CategoryName
                                                  }).ToListAsync();

            List<AttributeODTO> retval = new List<AttributeODTO>();
            foreach (var item in category)
            {
                AttributeODTO attributeValue = new AttributeODTO();
                attributeValue.CategoryId = item.CategoryId;
                attributeValue.CategoryName = item.CategoryName;
                attributeValue.Value = await (from x in _context.ProductAttributes
                                              where x.CategoriesId == item.CategoryId
                                              select x.Value).Distinct().ToListAsync();
                retval.Add(attributeValue);
            }

            return retval;
        }

        #endregion Product

        #region ProductAttributes

        private IQueryable<ProductAttributesODTO> GetProductAttributes(int id)
        {
            return from x in _context.ProductAttributes
                   where (id == 0 || x.ProductAttributeId == id)
                   select _mapper.Map<ProductAttributesODTO>(x);
        }

        public async Task<ProductAttributesODTO> GetProductAttributesById(int id)
        {
            return await GetProductAttributes(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<ProductAttributesODTO> AddProductAttributes(ProductAttributesIDTO productAttributesIDTO)
        {
            var productAttributes = _mapper.Map<ProductAttributes>(productAttributesIDTO);
            productAttributes.ProductAttributeId = 0;
            _context.ProductAttributes.Add(productAttributes);

            await SaveContextChangesAsync();

            return await GetProductAttributesById(productAttributes.ProductAttributeId);
        }

        public async Task<ProductAttributesODTO> EditProductAttributes(ProductAttributesIDTO productAttributesIDTO)
        {
            var productAttributes = _mapper.Map<ProductAttributes>(productAttributesIDTO);
            _context.Entry(productAttributes).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetProductAttributesById(productAttributes.ProductAttributeId);
        }

        public async Task<ProductAttributesODTO> DeleteProductAttributes(int id)
        {
            var productAttributes = await _context.ProductAttributes.FindAsync(id);
            if (productAttributes == null) return null;

            var productAttributesODTO = await GetProductAttributesById(id);
            _context.ProductAttributes.Remove(productAttributes);
            await SaveContextChangesAsync();
            return productAttributesODTO;
        }

        #endregion ProductAttributes

        #region SiteContent

        private IQueryable<SiteContentODTO> GetSiteContent(int id)
        {
            return from x in _context.SiteContents
                   where (id == 0 || x.SiteContentId == id)
                   select _mapper.Map<SiteContentODTO>(x);
        }

        public async Task<SiteContentODTO> GetSiteContentById(int id)
        {
            return await GetSiteContent(id).AsNoTracking().SingleOrDefaultAsync();
        }


        public async Task<SiteContentODTO> AddSiteContent(SiteContentIDTO siteContentIDTO)
        {
            int seo = 0;
            if (siteContentIDTO.SeoIDTO.GoogleKeywords != null || siteContentIDTO.SeoIDTO.GoogleKeywords != null)
            {
                seo = await AddSeo(siteContentIDTO.SeoIDTO.GoogleDesc, siteContentIDTO.SeoIDTO.GoogleKeywords);
            }

            var siteContent = _mapper.Map<SiteContent>(siteContentIDTO);
            siteContent.SiteContentTypeId = 0;
            siteContent.SeoId = (seo != 0) ? seo : null;
            _context.SiteContents.Add(siteContent);

            await SaveContextChangesAsync();

            return await GetSiteContentById(siteContent.SiteContentId);
        }

        public async Task<SiteContentODTO> EditSiteContent(SiteContentIDTO siteContentIDTO)
        {
            var siteContent = _mapper.Map<SiteContent>(siteContentIDTO);
            _context.Entry(siteContent).State = EntityState.Modified;

            var seo = await _context.Seos.Where(x => x.SeoId == siteContentIDTO.SeoId).SingleOrDefaultAsync();
            seo.GoogleDesc = siteContent.Seo.GoogleDesc;
            seo.GoogleKeywords = siteContent.Seo.GoogleKeywords;

            _context.Entry(seo).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetSiteContentById(siteContent.SiteContentId);
        }

        public async Task<SiteContentODTO> DeleteSiteContent(int id)
        {
            var siteContent = await _context.SiteContents.FindAsync(id);
            if (siteContent == null) return null;

            var siteContentODTO = await GetSiteContentById(id);

            _context.SiteContents.Remove(siteContent);
            await SaveContextChangesAsync();

            return siteContentODTO;
        }

        #endregion

        #region Order

        private IQueryable<OrderODTO> GetOrders(int id)
        {
            return from x in _context.Orders
                   where (id == 0 || x.OrderId == id)
                   select _mapper.Map<OrderODTO>(x);
        }

        public async Task<OrderODTO> GetOrderById(int id)
        {
            return await GetOrders(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<int> AnonimusOrRegistredUser(UsersIDTO usersIDTO)
        {
            var isUserExist = await _context.Users.Where(x => x.Email== usersIDTO.Email).Select(x => x.UsersId).SingleOrDefaultAsync();
            int UserID = isUserExist;
            if (isUserExist == 0)
            {
                    var user = await _userServices.AddUser(usersIDTO);
                    UserID = user.UsersId;
            }

            return UserID;
        }

        public async Task<List<OrderODTO>> GetAllOrder()
        {
            return await _context.Orders.Include(x => x.Users).Select(x => _mapper.Map<OrderODTO>(x)).ToListAsync();
        }

        public async Task<FullOrderODTO> GetFullOrderById(int id)
        {
            var order = await _context.Orders.Where(x => x.OrderId == id).SingleOrDefaultAsync();
            FullOrderODTO fullOrder = new FullOrderODTO();
            fullOrder.OrderId = id;
            var user = await _context.Users.Where(x => x.UsersId == order.UsersId).SingleOrDefaultAsync();
            fullOrder.Address = user.Address;
            fullOrder.City = user.City;
            fullOrder.Zip = user.Zip;
            fullOrder.Phone = user.Phone;
            fullOrder.Name = user.FirstName + " " + user.LastName;
            fullOrder.Status = order.OrderStatus;

            var products = await _context.OrderDetails.Where(x => x.OrderId == id).Select(x => x.ProductId).ToListAsync();
            List<ProductDetailsForOrderODTO> productList = new List<ProductDetailsForOrderODTO>();
            foreach (var item in products)
            {
                var product = await _context.Products.Where(x => x.ProductId == item).SingleOrDefaultAsync();
                ProductDetailsForOrderODTO productODTO = new ProductDetailsForOrderODTO();
                productODTO.ProductId = item;
                productODTO.ProductName = product.ProductName;
                productODTO.CategoriesId = product.CategoriesId;
                productODTO.CategoryName = await _context.Categories.Where(x => x.CategoryId == product.CategoriesId).Select(x => x.CategoryName).SingleOrDefaultAsync();
                productODTO.Price = product.Price;
                productODTO.Quantity = await _context.OrderDetails.Where(x => x.ProductId == item && x.OrderId == id).Select(x => x.Quantity).SingleOrDefaultAsync();

                productList.Add(productODTO);
            }

            fullOrder.TotalPrice = (from x in productList
                                    select x.Quantity * Convert.ToInt32(x.Price)).Sum();

            fullOrder.ProductODTO = productList;

            return fullOrder;
        }

        public async Task<OrderODTO> EditOrder(int id, string status)
        {
            var order = await _context.Orders.Where(x => x.OrderId == id).SingleOrDefaultAsync();
            order.OrderStatus = status;
            _context.Entry(order).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetOrderById(order.OrderId);
        }


        public async Task PostOrder(OrderDetailsIDTO orderIDTO)
        {
            var userId = await AnonimusOrRegistredUser(orderIDTO.UsersIDTO);
            OrderIDTO order = new OrderIDTO();
            order.OrderId = 0;
            order.UsersId = userId;
            order.OrderDate = DateTime.Now;
            order.OrderStatus = "On hold";

            var orderForDB = _mapper.Map<Order>(order);

            _context.Orders.Add(orderForDB);
            await SaveContextChangesAsync();

            var NewOrder = await GetOrderById(orderForDB.OrderId);

            foreach (var item in orderIDTO.ProductList)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = NewOrder.OrderId;
                orderDetails.ProductId = item;
                _context.OrderDetails.Add(orderDetails);
                await SaveContextChangesAsync();
            }
        }

        public async Task<OrderODTO> DeleteOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null) return null;

            var ordersODTO = await GetOrderById(id);

            _context.Orders.Remove(orders);
            await SaveContextChangesAsync();

            return ordersODTO;
        }

        #endregion

        #region Declaration

        private IQueryable<DeclarationODTO> GetDeclarations(int id)
        {
            return from x in _context.Declarations
                   where (id == 0 || x.DeclarationId == id)
                   select _mapper.Map<DeclarationODTO>(x);
        }

        public async Task<DeclarationODTO> GetDeclarationById(int id)
        {
            return await GetDeclarations(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<DeclarationODTO>> GetAll()
        {
            return await _context.Declarations.Select(x => _mapper.Map<DeclarationODTO>(x)).ToListAsync();
        }

        public async Task<DeclarationODTO> AddDeclaration(DeclarationIDTO declarationIDTO)
        {
            var declaration = _mapper.Map<Declaration>(declarationIDTO);
            declaration.DeclarationId = 0;
            _context.Declarations.Add(declaration);

            await SaveContextChangesAsync();

            return await GetDeclarationById(declaration.DeclarationId);
        }

        public async Task<DeclarationODTO> EditDeclaration(DeclarationIDTO declarationIDTO)
        {
            var declaration = _mapper.Map<Declaration>(declarationIDTO);
            _context.Entry(declaration).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetDeclarationById(declaration.DeclarationId);
        }

        public async Task<DeclarationODTO> DeleteDeclaration(int id)
        {
            var declaration = await _context.Declarations.FindAsync(id);
            if (declaration == null) return null;

            var declarationODTO = await GetDeclarationById(id);

            _context.Declarations.Remove(declaration);
            await SaveContextChangesAsync();

            return declarationODTO;
        }

        #endregion

        #region Media

        public async Task<List<MediaODTO>> GetAllMedia()
        {
            var media = await _context.Medias.Select(x => _mapper.Map<MediaODTO>(x)).ToListAsync();

            foreach (var item in media)
            {
                var index = item.Src.LastIndexOf('/');
                item.Src = item.Src.Substring(index+1);
            }

            return media;
        }

        //public async Task<List<MediaODTO>> DeleteMultipleMedia()

        #endregion
    }
}