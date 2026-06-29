using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace E_commerce.Application.DTOs.Baskes
{
    public class BasketItemDTO
    {
        [Required(ErrorMessage = "Product id must be exists")]
        public int Id { get; set; }
        [Range(1 , double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1 , 50)]
        public int Quantity { get; set; }
        public string PictureUrl { get; set; } = default!;
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; } = default!;



    }
}