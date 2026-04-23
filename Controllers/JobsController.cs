using JobTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private static List<Job> _jobs = new List<Job>
    {
      new Job
      {
          Id = 1,
          CompanyName = "Google",
          Position = "Backend Developer",
          Status = "Applied"
      }  ,
      new Job
      {
          Id = 2,
          CompanyName = "Microsoft",
          Position = ".NET Developer",
          Status = "Interview"
      }
    };


    [HttpGet]
    public IActionResult GetAllJobs()
    {
        return Ok(_jobs);
    }
}