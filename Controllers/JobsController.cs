using System.Diagnostics.Contracts;
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

    // Single Post 

    [HttpGet("{id}")]
    public IActionResult GetJobById(int id)
    {
        var job = _jobs.FirstOrDefault(j => j.Id == id);
        if (job == null) return NotFound("İlan bulunamadı.");
        return Ok(job);
    }

    // Add New Post 
    [HttpPost]
    public IActionResult CreateJob([FromBody] Job newJob)
    {
        newJob.Id = _jobs.Count + 1;
        _jobs.Add(newJob);
        return CreatedAtAction(nameof(GetJobById), new {id = newJob.Id}, newJob);

    }

    // Update Post
    [HttpPut("{id}")]
    public IActionResult UpdateJob(int id, [FromBody] Job updatedJob)
    {
        var job = _jobs.FirstOrDefault(j => j.Id == id);
        if(job == null) return NotFound("İlan bulunamadı.");

        job.CompanyName = updatedJob.CompanyName;
        job.Position = updatedJob.Position;
        job.Status = updatedJob.Status;
        job.Notes = updatedJob.Notes;

        return Ok(job);
    }

    // Delete Post

     [HttpDelete("{id}")]
    public IActionResult DeleteJob(int id)
    {
        var job = _jobs.FirstOrDefault(j => j.Id == id);
        if (job == null) return NotFound("İlan bulunamadı.");

        _jobs.Remove(job);
        return NoContent();
    }
}