using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTrackerAPI.Models;

namespace JobTrackerAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllJobs()
    {
        var jobs = await _context.Jobs.ToListAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetJobById(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return NotFound("İlan bulunamadı.");
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] Job newJob)
    {
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetJobById), new { id = newJob.Id }, newJob);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(int id, [FromBody] Job updatedJob)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return NotFound("İlan bulunamadı.");

        job.CompanyName = updatedJob.CompanyName;
        job.Position = updatedJob.Position;
        job.Status = updatedJob.Status;
        job.Notes = updatedJob.Notes;

        await _context.SaveChangesAsync();
        return Ok(job);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return NotFound("İlan bulunamadı.");

        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}