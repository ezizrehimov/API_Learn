using Business.DTOs.Product.Request;
using Business.Services.Abstract;
using Business.Services.Common;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<Response> CreateAsync(ProductCreateDto model)
        {
            return await service.CreateAsync(model);
        }

        [HttpGet("get")]
        public async Task<Response<Product>> GetAsync(int id)
        {
            return await service.getAsync(id);
        }

        [HttpGet("getAll")]
        public async Task<Response<List<Product>>> GetAllAsync()
        {
            return await service.getAllAsync();
        }

        [HttpPost("update")]
        public async Task<Response> UpdateAsync(int id,ProductUpdateDto model)
        {
            return await service.UpdateAsync(id, model);
        }
     }
}
