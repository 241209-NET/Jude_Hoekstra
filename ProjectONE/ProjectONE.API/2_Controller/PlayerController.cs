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
    
    [HttpGet]
    public IActionResult GetAllPlayers()
    {
        return Ok(_playerService.GetAllPlayers());
    }

    [HttpPost("equip/{name}")]
    public IActionResult equipItembyId(int id)
    {
        var item = _playerService.equipItemById(id);
        // puts item in inventory
        return Ok(item);
    }
}