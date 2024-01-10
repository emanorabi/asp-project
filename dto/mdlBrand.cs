using app2api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace app2api.dto
{
    public class mdlBrand
    {
        
        [MaxLength(100)]
        public string? Name { get; set; }
        public IFormFile LogoImage { get; set; }
    }
}
