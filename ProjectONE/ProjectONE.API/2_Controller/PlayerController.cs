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
    public IActionResult GetAllStats()
    {
        return Ok(_playerService.GetAllStats());
    }

    [HttpPost("equip/{name}")]
    public IActionResult equipItembyName(string name)
    {
        var item = _playerService.equipItemByName(name);
        // puts item in inventory
        return Ok(item);
    }
}