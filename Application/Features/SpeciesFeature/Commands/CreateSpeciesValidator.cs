using FluentValidation;

namespace Application.Features.SpeciesFeature.Commands;

public class CreateSpeciesValidator : AbstractValidator<CreateSpeciesCommand>
{
    public CreateSpeciesValidator()
    {
        RuleFor(x => x.Habitat)
            .NotEmpty().WithMessage("Habitat is required.")
            .MaximumLength(100).WithMessage("Habitat must not exceed 100 characters.");

        RuleFor(x => x.Atmosphere)
            .NotEmpty().WithMessage("Atmosphere is required.")
            .MaximumLength(100).WithMessage("Atmosphere must not exceed 100 characters.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.GeneralAtmosphere)
            .NotEmpty().WithMessage("General Atmosphere is required.")
            .MaximumLength(100).WithMessage("General Atmosphere must not exceed 100 characters.");

        RuleFor(x => x.TypeSpecie)
            .NotEmpty().WithMessage("Type Specie is required.")
            .MaximumLength(50).WithMessage("Type Specie must not exceed 50 characters.");
    }
}