using Business.DTOs.Product.Request;
using Business.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IProductService
    { 
        Task<Response> CreateAsync(ProductCreateDto model);
    }
}
