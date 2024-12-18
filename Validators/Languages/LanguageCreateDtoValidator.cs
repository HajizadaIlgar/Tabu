using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code bos ola bilmez")
                .MaximumLength(2)
                .WithMessage("Code uzunlugu 2 den artiq olmamalidir");

            RuleFor(x => x.Name)
                 .NotNull()
                .NotEmpty()
                .WithMessage("Code bos ola bilmez")
                .MaximumLength(64)
                .WithMessage("Code uzunlugu 64 den artiq olmamalidir");

            RuleFor(x => x.IconUrl)
                 .NotNull()
                .NotEmpty()
                .WithMessage("Code bos ola bilmez")
                .Matches("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?")
                .WithMessage("Icon-un deyeri Link olmalidir")
                .MaximumLength(128)
                .WithMessage("Code uzunlugu 128 den artiq olmamalidir");
        }
    }
}
