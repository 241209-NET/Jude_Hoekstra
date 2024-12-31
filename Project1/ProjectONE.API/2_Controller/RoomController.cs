using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectONE.API.Model;
using ProjectONE.API.Service;
namespace ProjectONE.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public IActionResult getallRoom()
    {
        var roomList = _roomService.getAllRoom();    
        return Ok(roomList);
    }
    

    [HttpPost("pickup/{name}")]
    public IActionResult pickupItembyName(string name)
    {
        var item = _roomService.pickupItemByName(name);
        // puts item in inventory
        return Ok(item);
    }
}