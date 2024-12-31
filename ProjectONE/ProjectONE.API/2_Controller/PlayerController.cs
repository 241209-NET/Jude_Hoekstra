using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectONE.API.Model;
using ProjectONE.API.Service;
namespace ProjectONE.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }
    
    // lists all players, probably want to change this later
    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        return Ok(_playerService.GetAllPlayers());
    }
    
    
    // this should list all items (not enemies) in the player's current room
    [HttpGet(template:"roomitems/")]
    public IActionResult LookAtItems()
    {
        return Ok(_playerService.LookAtItems());
    }
    
    //puts item in inventory
    [HttpPost("pickup/{id}")]
    public IActionResult PickupItemByID(int id)
    {
        var item = _playerService.PickupItemById(id);
        return Ok(item);
    }
    
    
    // equips item
    [HttpPost("equip/{id}")]
    public IActionResult EquipItembyId(int id)
    {
        var item = _playerService.EquipItemById(id);
        // puts item in inventory
        return Ok(item);
    }
    
}