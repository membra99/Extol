using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Universal.DTO.ODTO
{
    public class HomePageDataODTO
    {
        public List<string> BannerImages { get; set; } = new();
        public List<FeaturedCategories> FeaturedCategories { get; set; } = new();
        public List<FeaturedProducts> FeaturedProducts { get; set; } = new();
    }

    public class FeaturedProducts
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageSrc { get; set; }
    }

    public class ProductPageODTO
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<MaterialODTO>? MaterialODTO { get; set; }
        public List<ChildCategoryODTO>? ChildCategoryODTOs { get; set; }
    }

    public class ChildCategoryODTO
    {
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }

    public class PromotionODTO
    {
        public string? Title { get; set; }
        public string? Period { get; set; }
    }

    public class FeaturedCategories
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? MinPrice { get; set; }
        public string? ImageSrc { get; set; }
    }

    public class ProductsListODTO
    {
        public string? ProductName {  get; set; }
        public int categoryId {  get; set; }
        public List<MainCategoryODTO> MainCategoryODTOs { get; set; } = new();
    }

    public class MainCategoryODTO
    {
        public List<string>? Materials { get; set; }
        public CategoryDetailsODTO? CategoryDetailsODTOs { get; set; }
        public List<MaterialODTO>? MaterialByCategoryODTOs { get; set; } = new();
    }

    public class CategoryDetailsODTO
    {
        public List<ProfilesByMaterialODTO> PVC { get; set; } = new();
        public List<ProfilesByMaterialODTO> ALUMINIUM { get; set; } = new();
        public List<ProfilesByMaterialODTO> ALUPVC { get; set; } = new();
    }

    public class MaterialODTO
    {
        public string? Image { get; set; }
        public int? MaterialId { get; set; }
        public string? MaterialName { get; set; }
    }

    public class ProfilesByMaterialODTO
    {
        public string? Image { get; set; }
        public string? ProductName { get; set; }
    }
}
