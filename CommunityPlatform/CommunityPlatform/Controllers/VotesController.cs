using Microsoft.AspNetCore.Mvc;
using CommunityPlatform.Repository;
using CommunityPlatform.Repository.Models;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class VotesController : ControllerBase
{
    private readonly CommunityPlatformDbContext _context;

    public VotesController(CommunityPlatformDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetVotes()
    {
        return Ok(_context.Votes.ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVote(int id)
    {
        var vote = await _context.Votes.FindAsync(id);
        if (vote == null) return NotFound();
        return Ok(vote);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVote(Vote vote)
    {
        _context.Votes.Add(vote);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVote), new { id = vote.Id }, vote);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVote(int id, Vote vote)
    {
        if (id != vote.Id) return BadRequest();
        _context.Entry(vote).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVote(int id)
    {
        var vote = await _context.Votes.FindAsync(id);
        if (vote == null) return NotFound();
        _context.Votes.Remove(vote);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
