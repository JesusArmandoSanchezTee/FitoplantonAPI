using Application.Features.SpeciesFeature.Commands;
using Application.Features.SpeciesFeature.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeciesController : BaseApiController
{
    public SpeciesController(IMediator mediator) : base(mediator)
    {
        
    }
    
    /// <summary>
    /// Create a new species
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateSpecies([FromBody] CreateSpeciesCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    
    /// <summary>
    /// List all species
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetSpecies()
    {
        var response = await _mediator.Send(new SpeciesQuery());
        return Ok(response);
    }
}