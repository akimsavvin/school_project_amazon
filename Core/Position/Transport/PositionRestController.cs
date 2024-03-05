using System.Net;
using Amazon.Core.Position.Dto;
using Amazon.Core.Position.Exceptions;
using Amazon.Core.Position.Models;
using Amazon.Core.Position.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Core.Position.Transport;

[ApiController]
[Route("/api/positions")]
public class PositionRestController(IPositionService positionService) : ControllerBase
{
    private readonly IPositionService _positionService = positionService;

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PositionModel>))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var positions = await _positionService.GetAllAsync();
            return Ok(positions);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PositionModel))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PositionNotFoundException))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetOneByIdAsync(Guid id)
    {
        try
        {
            var position = await _positionService.GetOneAsync(id);
            return Ok(position);
        }
        catch (PositionNotFoundException exception)
        {
            return NotFound(exception);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(PositionModel))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CreateAsync(CreatePositionDto createPositionDto)
    {
        try
        {
            var position = await _positionService.CreateAsync(createPositionDto);
            return Ok(position);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(PositionNotFoundException))]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteOneByIdAsync(Guid id)
    {
        try
        {
            await _positionService.DeleteByIdAsync(id);
            return NoContent();
        }
        catch (PositionNotFoundException exception)
        {
            return NotFound(exception);
        }
        catch (Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }
}
