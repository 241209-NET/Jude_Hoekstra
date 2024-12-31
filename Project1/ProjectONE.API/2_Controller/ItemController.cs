using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjectONE.API.Service;
namespace ProjectONE.API._2_Controller;

[Route("api/[controller]")]
[ApiController]
public class ItemController
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }
    
    [HttpGet]
    public IActionResult GetAllStats()
    {
        // returns description and stuff
        return Ok(_itemService.GetAllStats());
    }
}