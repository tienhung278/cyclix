using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikesController : Controller
{
    private readonly IBikeServices _bikeServices;

    public BikesController(IServiceManager serviceManager)
    {
        _bikeServices = serviceManager.BikeServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var bikes = await _bikeServices.FindBikesAsync();
        return Ok(bikes);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var bike = await _bikeServices.FindBikeAsync(id);
            return Ok(bike);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(BikeWriteDto bikeWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        var id = await _bikeServices.CreateBikeAsync(bikeWriteDto);
        return Created($"/bikes/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] BikeWriteDto bikeWriteDto)
    {
        try
        {
            await _bikeServices.UpdateBikeAsync(id, bikeWriteDto);
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
            await _bikeServices.DeleteBikeAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}