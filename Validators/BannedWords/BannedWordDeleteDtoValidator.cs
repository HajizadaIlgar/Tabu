using FluentValidation;
using Tabu.DTOs.BannedWords;

namespace Tabu.Validators.BannedWords
{
    public class BannedWordDeleteDtoValidator : AbstractValidator<BannedWordDeleteDto>
    {
        public BannedWordDeleteDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data null ola bilmez")
                .MaximumLength(32);
        }
    }
}
