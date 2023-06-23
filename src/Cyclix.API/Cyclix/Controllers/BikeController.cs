using Cyclix.Models.Dtos;
using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BikeController : Controller
{
    private readonly IBikeServices _bikeServices;

    public BikeController(IBikeServices bikeServices)
    {
        _bikeServices = bikeServices;
    }

    [HttpGet]
    public IActionResult GetBike()
    {
        return Ok(_bikeServices.GetBike());
    }

    [HttpPost]
    public IActionResult CreateBike(BikeWriteDto bikeWriteDto)
    {
        _bikeServices.CreateBike(bikeWriteDto);
        return Ok();
    }
}