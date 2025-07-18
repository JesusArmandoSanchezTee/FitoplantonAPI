using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.SpeciesFeature.Querys;

public record SpeciesQuery() : IRequest<Response<List<SpeciesDto>>>;

public class SpeciesQueryHandler : IRequestHandler<SpeciesQuery, Response<List<SpeciesDto>>>
{
    public readonly IRepositoryAsync<Species> _repository;
    
    public SpeciesQueryHandler(IRepositoryAsync<Species> repository)
    {
        _repository = repository;
    }
    public async Task<Response<List<SpeciesDto>>> Handle(SpeciesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.ListAsync(cancellationToken);
        var dtoList = result.Select(species => new SpeciesDto
        {
            Id = species.Id,
            Habitat = species.Habitat,
            Atmosphere = species.Atmosphere,
            Name = species.Name,
            GeneralAtmosphere = species.GeneralAtmosphere,
            TypeSpecie = species.TypeSpecie
        }).ToList();
        
        return new Response<List<SpeciesDto>>(dtoList);
    }
}