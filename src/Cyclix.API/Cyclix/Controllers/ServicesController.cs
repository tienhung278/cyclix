using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicesController : Controller
{
    private readonly IServiceServices _serviceServices;

    public ServicesController(IServiceManager serviceManager)
    {
        _serviceServices = serviceManager.ServiceServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var services = await _serviceServices.FindServicesAsync();
        return Ok(services);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var service = await _serviceServices.FindServiceAsync(id);
            return Ok(service);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ServiceWriteDto serviceWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _serviceServices.CreateServiceAsync(serviceWriteDto);
        return Created($"/services/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] ServiceWriteDto serviceWriteDto)
    {
        try
        {
            await _serviceServices.UpdateServiceAsync(id, serviceWriteDto);
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
            await _serviceServices.DeleteServiceAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}