using FluentValidation;
using Tabu.DTOs.BannedWords;

namespace Tabu.Validators.BannedWords
{
    public class BannedWordCreateDtoValidator : AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .WithMessage("Data null ola bilmez")
                .MaximumLength(32);
        }
    }
}
