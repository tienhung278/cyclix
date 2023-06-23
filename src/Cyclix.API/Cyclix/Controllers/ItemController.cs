using Cyclix.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cyclix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : Controller
{
    private readonly IItemServices _itemServices;

    public ItemController(IItemServices itemServices)
    {
        _itemServices = itemServices;
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(_itemServices.GetItems());
    }
}