using AutoMapper;
using Business.DTOs.Product.Request;
using Business.Exceptions;
using Business.Services.Abstract;
using Business.Services.Common;
using Business.Validations.Product;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IUnitofWork unitofWork;

        public ProductService(IMapper mapper, IProductRepository repository, IUnitofWork unitofWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitofWork = unitofWork;
        }
        public async Task<Response> CreateAsync(ProductCreateDto model)
        {
            var result = await new ProductCreateDtoValidator().ValidateAsync(model);
            if (!result.IsValid)
                throw new ValidatorException(result.Errors);

            var product = mapper.Map<Product>(model);

            await repository.Create(product);

            await unitofWork.CommitAsync();

            return new Response
            {
                Message="Mehsul Ugurla yaradildi."
            };
        }
    }
}
