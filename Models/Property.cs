using System.ComponentModel.DataAnnotations;

namespace PropertyFinderApi.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? PropertyId { get; set; }
        
        public string? Description { get; set; }
        
        [MaxLength(255)]
        public string? Street { get; set; }
        
        [MaxLength(100)]
        public string? City { get; set; }
        
        [MaxLength(2)]
        public string? State { get; set; }
        
        [MaxLength(10)]
        public string? Zip { get; set; }
        
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
