using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypesController : Controller
{
    private readonly ITypeServices _typeServices;

    public TypesController(IServiceManager serviceManager)
    {
        _typeServices = serviceManager.TypeServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var types = await _typeServices.FindTypesAsync();
        return Ok(types);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var type = await _typeServices.FindTypeAsync(id);
            return Ok(type);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TypeWriteDto typeWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _typeServices.CreateTypeAsync(typeWriteDto);
        return Created($"/types/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] TypeWriteDto typeWriteDto)
    {
        try
        {
            await _typeServices.UpdateTypeAsync(id, typeWriteDto);
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
            await _typeServices.DeleteTypeAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}