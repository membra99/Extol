using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.DTO.ODTO
{
    public class ProfilesODTO
    {
        public int ProfileId { get; set; }
        public int CategoryId { get; set; }
        public string? ProfileName { get; set; }
        public int? MediaId { get; set; }
        public string? mediaSRC { get; set; }
        public int MaterialId { get; set; }
        public string? MaterialName { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? Price { get; set; } = "HardCoded";
    }

    public class ProfilesAndProductsODTO
    {
        public List<ProfilesODTO>? Profiles { get; set; }
        public List<FeaturedProducts>? FeaturedProducts { get; set; }
    }
}
