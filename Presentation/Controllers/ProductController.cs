using Business.DTOs.Product.Request;
using Business.Services.Abstract;
using Business.Services.Common;
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
           return  await service.CreateAsync(model);
        }
    }
}
