using Business.DTOs.Product.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.Product
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Basliq bos ola bilmez")
                .MinimumLength(4)
                .WithMessage("Basliq minimum 4 simvol olmalidir");

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("Qiymet mutleq daxil edilmelidir")
                .GreaterThan(100)
                .WithMessage("Qiymet 100 den asagi ola bilmez");
        }
    }
}
