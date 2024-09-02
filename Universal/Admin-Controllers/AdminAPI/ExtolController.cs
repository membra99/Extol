using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Services;
using Universal.DTO.ODTO;

namespace Universal.Admin_Controllers.AdminAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ExtolController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public ExtolController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        [HttpGet("AllProfilesByCategory")]
        public async Task<ActionResult<IEnumerable<ProfilesODTO>>> GetProfilesByCategoryId(int categoryId)
        {
            var profiles = await _mainDataServices.GetProfilesByCategoryId(categoryId);
            if (profiles == null)
            {
                return NotFound();
            }
            return profiles;
        }

        [HttpGet("AllCategoryTypes")]
        public async Task<ActionResult<IEnumerable<CategoryTypesODTO>>> GetAllCategoryTypesByCategoryId(int categoryId)
        {
            var categoryTypes = await _mainDataServices.GetAllCategoryTypesByCategoryId(categoryId);
            if (categoryTypes == null)
            {
                return NotFound();
            }
            return categoryTypes;
        }

        [HttpGet("Configurator")]
        public async Task<ActionResult<ConfiguratorODTO>> GetConfiguratorParams(int categoryId, int categoryTypeId, int materialId, int profileId)
        {
            var categoryTypes = await _mainDataServices.GetConfiguratorParams(categoryId, categoryTypeId, materialId, profileId);
            if (categoryTypes == null)
            {
                return NotFound();
            }
            return categoryTypes;
        }

        [HttpGet("Promotion")]
        public async Task<ActionResult<PromotionODTO>> GetPromotions()
        {
            var promotion = await _mainDataServices.GetPromotion();
            if (promotion == null)
            {
                return NotFound();
            }
            return promotion;
        }

        [HttpGet("ProductPageCategory")]
        public async Task<ActionResult<IEnumerable<ProductPageODTO>>> GetProductPageCategories()
        {
            var ProductPage = await _mainDataServices.GetProductPageCategory();
            if (ProductPage == null)
            {
                return NotFound();
            }
            return ProductPage;
        }

        [HttpGet("FilterProducts")]
        public async Task<ActionResult<ProfilesAndProductsODTO>> FilterProducts(int categoryId, int? materialId)
        {
            var FilterProduct = await _mainDataServices.FilterProduct(categoryId,materialId);
            if (FilterProduct == null)
            {
                return NotFound();
            }
            return FilterProduct;
        }


        [HttpPost("SendMail")]
        public async Task<ActionResult<string>> FilterProducts(string ime, string prezime, string email, string poruka)
        {
            var mail = await _mainDataServices.SendMail(ime,prezime,email,poruka);
            if (mail == null)
            {
                return NotFound();
            }
            return mail;
        }


        [HttpGet("SingleProductPage")]
        public async Task<ActionResult<SppODTO>> GetDataForSPP(int? categoryId, int? profileId)
        {
            var sppData = await _mainDataServices.GetDataForSPP(categoryId, profileId);
            if (sppData == null)
            {
                return NotFound();
            }
            return sppData;
        }

        [HttpGet("HomePage")]
        public async Task<ActionResult<HomePageDataODTO>> GetHomePageData()
        {
            var homepage = await _mainDataServices.GetDataForHomePage();
            if (homepage == null)
            {
                return NotFound();
            }
            return homepage;
        }

        [HttpGet("ProductTree")]
        public async Task<ActionResult<IEnumerable<ProductsListODTO>>> GetProductTree()
        {
            var homepage = await _mainDataServices.GetProductTrees();
            if (homepage == null)
            {
                return NotFound();
            }
            return homepage;
        }

    }
}
