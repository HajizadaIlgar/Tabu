using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageDeleteDtoValidator : AbstractValidator<LanguageDeleteDto>
    {
        public LanguageDeleteDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("Code bos ola bilmez")
                .MaximumLength(2)
                .WithMessage("Code uzunlugu 2 den artiq olmamalidir");
        }
    }
}
