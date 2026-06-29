using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Baskes
{
    public class BasketDTO
    {
        public string Id { get; set; } = default!;
        public ICollection<BasketItemDTO> items { get; set; } = [];
    }
}
