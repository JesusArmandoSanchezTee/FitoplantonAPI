using Application.Wrappers;
using MediatR;

namespace Application.Features.ClasificationSpeciesFeature.Commands.Create;

public class CreateClasificationCommand : IRequest<Response<int>>
{
    public string Empire { get; set; }
    public string Phylum { get; set; }
    public string SubPhylum { get; set; }
    public string Kingdom { get; set; }
    public string Class { get; set; }
    public string SubClass { get; set; }
    public string Order { get; set; }
    public string Family { get; set; }
    public string Genus { get; set; }
    public int SpeciesId { get; set; }
}