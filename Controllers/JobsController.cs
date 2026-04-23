using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok("İlk endpoint çalışıyor! 🎉");
    }
}