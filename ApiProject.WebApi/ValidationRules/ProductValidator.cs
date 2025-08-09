using ApiProject.WebApi.Entities;
using FluentValidation;

namespace ApiProject.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez.");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakterden oluşmalıdır.");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakterden oluşmalıdır.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilmez.").
                GreaterThan(0).WithMessage("Ürün fiyatı 0'dan az olamaz.").
                LessThan(10000).WithMessage("Ürün fiyatı 10000 liradan yüksek olamaz.");

            RuleFor(x=>x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.");
        }
    }
}
