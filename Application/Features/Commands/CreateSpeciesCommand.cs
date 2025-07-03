using Application.Wrappers;
using MediatR;

namespace Application.Features.Commands;

public class CreateSpeciesCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Habitat { get; set; }
    public string Atmosphere { get; set; }
    public string Name { get; set; }
    public string GeneralAtmosphere { get; set; }
    public string TypeSpecie { get; set; }
}

public class CreateSpeciesCommandHandler : IRequestHandler<CreateSpeciesCommand, Response<int>>
{
    public async Task<Response<int>> Handle(CreateSpeciesCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

