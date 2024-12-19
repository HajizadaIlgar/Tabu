using FluentValidation;
using Tabu.DTOs.BannedWords;

namespace Tabu.Validators.BannedWords
{
    public class BannedWordUpdateDtoValidator : AbstractValidator<BannedWordUpdateDto>
    {
        public BannedWordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data null ola bilmez")
                .MaximumLength(32);
        }
    }
}
