using System.ComponentModel.DataAnnotations;

namespace app2api.Data.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        public byte[]? LogoImage { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
