using Application.Wrappers;
using MediatR;

namespace Application.Features.SpeciesFeature.Commands;

public class CreateSpeciesCommand() : IRequest<Response<int>>
{
    public string Habitat { get; set; }
    public string Atmosphere { get; set; }
    public string Name { get; set; }
    public string GeneralAtmosphere { get; set; }
    public string TypeSpecie { get; set; }
}


