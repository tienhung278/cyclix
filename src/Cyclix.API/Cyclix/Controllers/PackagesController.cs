using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PackagesController : Controller
{
    private readonly IPackageServices _packageServices;

    public PackagesController(IServiceManager serviceManager)
    {
        _packageServices = serviceManager.PackageServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var packages = await _packageServices.FindPackagesAsync();
        return Ok(packages);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var package = await _packageServices.FindPackageAsync(id);
            return Ok(package);
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"{id} was not found" });
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PackageWriteDto packageWriteDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var id = await _packageServices.CreatePackageAsync(packageWriteDto);
        return Created($"/packages/{id}", null);
    }
    
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(long id, [FromBody] PackageWriteDto packageWriteDto)
    {
        try
        {
            await _packageServices.UpdatePackageAsync(id, packageWriteDto);
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
            await _packageServices.DeletePackageAsync(id);
            return NoContent();
        }
        catch (NullReferenceException exception)
        {
            return NotFound(new { message = $"id {id} was not found" });
        }
    }
}