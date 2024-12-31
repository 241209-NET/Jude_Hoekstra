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
    public IActionResult GetallRooms()
    {
        var roomList = _roomService.GetAllRooms();    
        return Ok(roomList);
    }
    

    [HttpPost("pickup/{name}")]
    public IActionResult pickupItembyId(int id)
    {
        var item = _roomService.pickupItemById(id);
        // puts item in inventory
        return Ok(item);
    }
}