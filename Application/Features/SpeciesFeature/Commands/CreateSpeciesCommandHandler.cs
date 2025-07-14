using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using Domain.Entities;

namespace Application.Features.SpeciesFeature.Commands;

public class CreateSpeciesCommandHandler : IRequestHandler<CreateSpeciesCommand, Response<int>>
{
    private readonly IRepositoryAsync<Species> _repository;

    public CreateSpeciesCommandHandler(IRepositoryAsync<Species> repository)
    {
        _repository = repository;
    }
    
    public async Task<Response<int>> Handle(CreateSpeciesCommand request, CancellationToken cancellationToken)
    {
        var species = new Species
        {
            Habitat = request.Habitat,
            Atmosphere = request.Atmosphere,
            Name = request.Name,
            GeneralAtmosphere = request.GeneralAtmosphere,
            TypeSpecie = request.TypeSpecie,
        };
        
        await _repository.AddAsync(species, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        
        return new Response<int>(species.Id);
    }
}