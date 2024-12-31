/*

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
    public IActionResult GetItemByName(string n)
    {
        // returns description and stuff
        // it might be best just to get rid of this and enemy controller
        
        return Ok(_itemService.GetAllStats());
    }
}

*/