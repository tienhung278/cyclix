using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OptionsController : Controller
{
    private readonly IOptionServices _optionServices;

    public OptionsController(IServiceManager serviceManager)
    {
        _optionServices = serviceManager.OptionServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var options = await _optionServices.FindOptionsAsync();
        return Ok(options);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var option = await _optionServices.FindOptionAsync(id);
            return Ok(option);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OptionWriteDto optionWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _optionServices.CreateOptionAsync(optionWriteDto);
        return Created($"/options/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] OptionWriteDto optionWriteDto)
    {
        try
        {
            await _optionServices.UpdateOptionAsync(id, optionWriteDto);
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
            await _optionServices.DeleteOptionAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}