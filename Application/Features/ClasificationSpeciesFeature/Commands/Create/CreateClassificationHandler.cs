using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;

namespace Application.Features.ClasificationSpeciesFeature.Commands.Create;

public class CreateClassificationHandler : IRequestHandler<CreateClasificationCommand, Response<int>>
{
    public readonly IRepositoryAsync<ClasificationSpecies> _repository;
    public readonly IRepositoryAsync<Species> _speciesRepository;
    
    public CreateClassificationHandler(IRepositoryAsync<ClasificationSpecies> repository, IRepositoryAsync<Species> speciesRepository)
    {
        _repository = repository;
        _speciesRepository = speciesRepository;
    }
    public async Task<Response<int>> Handle(CreateClasificationCommand request, CancellationToken cancellationToken)
    {
        
        var verification = await _speciesRepository.GetByIdAsync(request.SpeciesId, cancellationToken);

        if (verification == null)
        {
            return new Response<int>("Species not found");
        }
        
        var classification = new ClasificationSpecies
        {
            Empire = request.Empire,
            Phylum = request.Phylum,
            Subphylum = request.SubPhylum,
            Kingdom = request.Kingdom,
            Class = request.Class,
            Subclass = request.SubClass,
            Order = request.Order,
            Family = request.Family,
            Genus = request.Genus,
            SpeciesId = request.SpeciesId
        };
        
        await _repository.AddAsync(classification, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
        return new Response<int>(classification.Id);
    }
}