using AutoMapper;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));

            CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));

            CreateMap<Product, ProductDto>()
           .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name));
        }
    }
}
