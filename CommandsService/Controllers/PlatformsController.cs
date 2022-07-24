﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;  

[Route("api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {
            
    }

    [HttpPost]
    public ActionResult TestInboundConnections()
    {
        Console.WriteLine("--> Inbound POST # Command Service");
        return Ok("Inbound test of from PlatformsConftroller");
    }
}