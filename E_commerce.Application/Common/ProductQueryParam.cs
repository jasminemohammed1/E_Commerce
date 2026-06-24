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

        
        public int PageIndex { get; set; } = 1;
        private const int MaxPageSize = 10;
        private const int DefaultPageSize = 5;
        private int pagesize = DefaultPageSize;
        public int PageSize {
            get => pagesize;
            set => pagesize = (value > MaxPageSize ? MaxPageSize : (value < 1 ? DefaultPageSize : value));

           
          }
    }
}
