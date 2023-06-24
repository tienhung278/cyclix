using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnotherOptionsController : Controller
{
    private readonly IAnotherOptionServices _anotherOptionServices;

    public AnotherOptionsController(IServiceManager serviceManager)
    {
        _anotherOptionServices = serviceManager.AnotherOptionServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnotherOptions()
    {
        var anotherOptions = await _anotherOptionServices.FindAnotherOptionsAsync();
        return Ok(anotherOptions);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnotherOption(long id)
    {
        try
        {
            var anotherOption = await _anotherOptionServices.FindAnotherOptionAsync(id);
            return Ok(anotherOption);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AnotherOptionWriteDto anotherOptionWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _anotherOptionServices.CreateAnotherOptionAsync(anotherOptionWriteDto);
        return Created($"/anotherOptions/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] AnotherOptionWriteDto anotherOptionWriteDto)
    {
        try
        {
            await _anotherOptionServices.UpdateAnotherOptionAsync(id, anotherOptionWriteDto);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
    
    [HttpDelete("{id}")] 
    public async Task<IActionResult> Put(long id)
    {
        try
        {
            await _anotherOptionServices.DeleteAnotherOptionAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}