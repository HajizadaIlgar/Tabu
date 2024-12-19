using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .WithMessage("Null ola bilmez !")
                .MaximumLength(32)
                .WithMessage("simvol sayi 32 den cox ola bilmez");
            RuleFor(x => x.BannedWords)
                .NotNull();

            RuleFor(x => x.BannedWords)
                .Must(x => x.Count() == 8);

            RuleForEach(x => x.BannedWords)
                .NotNull()
                .WithMessage("data Null ola bilmez")
                .MaximumLength(132)
                .WithMessage("simvol 32 den cox olmamalidir");
        }
    }
}
