using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : Controller
{
    private readonly IBrandServices _brandServices;

    public BrandsController(IServiceManager serviceManager)
    {
        _brandServices = serviceManager.BrandServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var brands = await _brandServices.FindBrandsAsync();
        return Ok(brands);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var brand = await _brandServices.FindBrandAsync(id);
            return Ok(brand);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BrandWriteDto brandWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _brandServices.CreateBrandAsync(brandWriteDto);
        return Created($"/brands/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] BrandWriteDto brandWriteDto)
    {
        try
        {
            await _brandServices.UpdateBrandAsync(id, brandWriteDto);
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
            await _brandServices.DeleteBrandAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}