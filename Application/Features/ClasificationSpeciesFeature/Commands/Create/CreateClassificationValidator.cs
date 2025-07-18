using FluentValidation;

namespace Application.Features.ClasificationSpeciesFeature.Commands.Create;

public class CreateClassificationValidator : AbstractValidator<CreateClasificationCommand>
{
    public CreateClassificationValidator()
    {
        RuleFor(x => x.Empire)
            .NotEmpty().WithMessage("Empire is required.")
            .MaximumLength(50).WithMessage("Empire must not exceed 50 characters.");

        RuleFor(x => x.Phylum)
            .NotEmpty().WithMessage("Phylum is required.")
            .MaximumLength(50).WithMessage("Phylum must not exceed 50 characters.");

        RuleFor(x => x.SubPhylum)
            .NotEmpty().WithMessage("SubPhylum is required.")
            .MaximumLength(50).WithMessage("SubPhylum must not exceed 50 characters.");

        RuleFor(x => x.Kingdom)
            .NotEmpty().WithMessage("Kingdom is required.")
            .MaximumLength(50).WithMessage("Kingdom must not exceed 50 characters.");

        RuleFor(x => x.Class)
            .NotEmpty().WithMessage("Class is required.")
            .MaximumLength(50).WithMessage("Class must not exceed 50 characters.");

        RuleFor(x => x.SubClass)
            .NotEmpty().WithMessage("SubClass is required");
    }
}