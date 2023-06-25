using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : Controller
{
    private readonly IRequestServices _requestServices;

    public RequestsController(IServiceManager serviceManager)
    {
        _requestServices = serviceManager.RequestServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var requests = await _requestServices.FindRequestsAsync();
        return Ok(requests);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var request = await _requestServices.FindRequestAsync(id);
            return Ok(request);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest()
    {
        var request = await _requestServices.FindLatestRequestAsync();
        return Ok(request);
    }

    [HttpPost]
    public async Task<IActionResult> Post(RequestWriteDto requestWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var id = await _requestServices.CreateRequestAsync(requestWriteDto);
        return Created($"/requests/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] RequestWriteDto requestWriteDto)
    {
        try
        {
            await _requestServices.UpdateRequestAsync(id, requestWriteDto);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
    
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await _requestServices.DeleteRequestAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}