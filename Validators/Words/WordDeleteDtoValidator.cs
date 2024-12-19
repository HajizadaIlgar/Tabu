using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordDeleteDtoValidator : AbstractValidator<WordDeleteDto>
    {
        public WordDeleteDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Text)
               .NotEmpty()
               .NotNull()
               .WithMessage("Null ola bilmez !");
        }
    }
}
