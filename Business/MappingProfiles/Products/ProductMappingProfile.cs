using AutoMapper;
using Business.DTOs.Product.Request;
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
        }
    }
}
