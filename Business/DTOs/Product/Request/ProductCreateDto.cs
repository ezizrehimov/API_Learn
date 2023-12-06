using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Product.Request
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Photo { get; set; }
    }
}
