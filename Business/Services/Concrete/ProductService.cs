using AutoMapper;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Business.Exceptions;
using Business.Services.Abstract;
using Business.Services.Common;
using Business.Validations.Product;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitofWork;
using FluentValidation;
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

            product.CreatedAt = DateTime.Now;

            await repository.Create(product);


            await unitofWork.CommitAsync();

            return new Response
            {
                Message = "Product ugurla yaradildi"
            };



        }


        public async Task<Response> DeleteAsync(int id)
        {
            var product = await repository.GetAsync(id);
            if (product is null)
                throw new NotFoundException($"{id} id-li product tapilmadi");

            repository.Delete(product);
            await unitofWork.CommitAsync();
            return new Response
            {
                Message = "Mehsul ugurla silindi"
            };


        }


        public async Task<Response<List<ProductDto>>> getAllAsync()
        {
            var products = await repository.GetAllAsync();


            var productDtos = mapper.Map<List<ProductDto>>(products);

            return new Response<List<ProductDto>>
            {
                Data = productDtos
            };
        }

        public async Task<Response<ProductDto>> getAsync(int id)
        {
            var product = await repository.GetAsync(id);
            if (product is null)
                throw new NotFoundException($"{id} id-li product tapilmadi");

            var productDto = mapper.Map<ProductDto>(product);


            return new Response<ProductDto>
            {
                Data = productDto
            };
        }

        public async Task<Response> UpdateAsync(int id, ProductUpdateDto model)
        {
            var product = await repository.GetAsync(id);
            if (product is null)
                throw new NotFoundException($"{id} id-li product tapilmadi");

            var result = await new ProductUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)

                throw new ValidatorException(result.Errors);

            product = mapper.Map(model, product);

            repository.Update(product);
            product.ModifiedAt = DateTime.Now;
            await unitofWork.CommitAsync();

            return new Response
            {
                Message = "Mehsul ugurla yenilendi"
            };


        }
    }
}