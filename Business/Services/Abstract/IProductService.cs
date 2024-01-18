using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Business.Services.Common;
using Common.Entities;
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
        Task<Response> DeleteAsync(int id);
        Task<Response<List<ProductDto>>> getAllAsync();
        Task<Response<ProductDto>> getAsync(int id);
        Task<Response> UpdateAsync(int id, ProductUpdateDto model);
    }
}
