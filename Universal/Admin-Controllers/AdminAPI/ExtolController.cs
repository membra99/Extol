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
    }
}
