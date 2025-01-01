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
    
    [HttpDelete("reset")]
    public IActionResult ResetEverything()
    {
        var item = _playerService.ResetEverything();
        return Ok(item);
    }
    
    // this should list all items (not enemies) in the player's current room
    [HttpGet(template:"lookaround/{playerid}")]
    public IActionResult LookAtItems(int playerid)
    {
        return Ok(_playerService.LookAtItems(playerid));
    }

    [HttpGet(template: "playeritems/{playerid}")]
    public IActionResult LookAtInventory(int playerid)
    {
        return Ok(_playerService.LookAtInventory(playerid));
    }
    
    //puts item in inventory
    [HttpPost("pickup/{playerid}/{id}")]
    public IActionResult PickupItemByID(int playerid, int id)
    {
        var item = _playerService.PickupItemById(playerid, id);
        return Ok(item);
    }
    
    
    // equips item
    [HttpPost("equip/{playerid}/{id}")]
    public IActionResult EquipItembyId(int playerid, int id)
    {
        var item = _playerService.EquipItemById(playerid, id);
        // puts item in inventory
        return Ok(item);
    }

    [HttpPost("attack/{playerid}/{id}")]
    public IActionResult AttackEnemyById(int playerid, int id)
    {
        var item = _playerService.AttackEnemyById(playerid, id);
        // puts item in inventory
        return Ok(item);
    }
    
    
}