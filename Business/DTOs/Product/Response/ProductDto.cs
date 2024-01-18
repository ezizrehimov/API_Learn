﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Product.Response
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
