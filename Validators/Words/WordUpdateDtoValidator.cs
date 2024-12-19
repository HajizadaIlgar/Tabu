using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordUpdateDtoValidator : AbstractValidator<WordUpdateDto>
    {
        public WordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Null ola bilmez !")
               .MaximumLength(32)
               .WithMessage("simvol sayi 32 den cox ola bilmez");
            RuleFor(x => x.BannedWords)
                .NotNull();

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .WithMessage("data Null ola bilmez")
                .MaximumLength(32)
                .WithMessage("simvol 32 den cox olmamalidir");
        }
    }
}
