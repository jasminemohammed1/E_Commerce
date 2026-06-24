using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Common
{
   public class ProductQueryParam
    {
        public int ?BrandId { get; set; }
        public int ?TypeId { get; set; }
        public string ?SearchValue { get; set; }
        public ProductSearchValues Sort { get; set; }
    }
}
