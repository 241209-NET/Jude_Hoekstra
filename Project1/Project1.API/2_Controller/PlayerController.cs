using Microsoft.AspNetCore.Mvc;

namespace Project1.Controller;

[Route("/")]
[ApiController]
public class PlayerController : ControllerBase
{    
    [HttpGet] //change to display player stats
    public IActionResult Welcome()
    {
        return Ok("Hello World");
    }
}