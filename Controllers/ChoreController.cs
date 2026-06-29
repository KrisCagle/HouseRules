using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRules.Data;
using Microsoft.EntityFrameworkCore;
using HouseRules.Models;
using HouseRules.Models.DTOs;
using AutoMapper;
using System.Security.Claims;

namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChoreController : ControllerBase
{
    private HouseRulesDbContext _dbContext;
    private readonly IMapper _mapper;

    public ChoreController(HouseRulesDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }


[HttpGet]
// [Authorize]
public IActionResult Get()
{
    List<Chore> chores = _dbContext
        .Chores
        .ToList();
    List<ChoreDto> dtos = _mapper.Map<List<ChoreDto>>(chores);
    return Ok(dtos);
}

[HttpGet("{id}")]
[Authorize]
public IActionResult GetById(int id)
    {
        Chore chore = _dbContext
        .Chores
        .Include(b => b.ChoreAssignments)
        .Include(b => b.ChoreCompletions )
        .SingleOrDefault(b => b.Id == id);
        

        if (chore == null)
        {
            return NotFound();
        }
        return Ok(chore);
        
    }

[HttpPost("{id}/complete")]
[Authorize]
public IActionResult GetByIdComplete(int id, [FromQuery] int userId)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault( c => c.Id == id);
        if (chore == null)
        {
            return NotFound();
        }
        var completion = new ChoreCompletion
        {
            UserProfileId = id,
            ChoreId = id,
            CompletedOn = DateTime.UtcNow
        };
        _dbContext.ChoreCompletions.Add(completion);
        _dbContext.SaveChanges();
        return NoContent();
    }

[HttpPost]
[Authorize]
public IActionResult NewChore(Chore newChore)

    {
        Chore chore = new Chore
        {
            Name = newChore.Name,
            Difficulty = newChore.Difficulty,
            ChoreFrequencyDays = newChore.ChoreFrequencyDays
        };
        _dbContext.Chores.Add(chore);
        _dbContext.SaveChanges();
        return NoContent();
}




[HttpPut("{id}")]
[Authorize]
public IActionResult UpdateChore(int id, Chore updatedChore)
    {
        Chore chore = _dbContext.Chores
        .SingleOrDefault(c => c.Id == id);
        if (chore == null)
        {
            return NotFound();
        }
        chore.Name = updatedChore.Name;
        chore.Difficulty = updatedChore.Difficulty;
        chore.ChoreFrequencyDays = updatedChore.ChoreFrequencyDays;
        _dbContext.SaveChanges();
        return NoContent();
    }

[HttpDelete("{id}")]
[Authorize]
public IActionResult DeleteChore(int id)
    {
        Chore chore = _dbContext.Chores
        .SingleOrDefault(c => c.Id == id);
        if (chore == null)
        {
            return NotFound();
        }
        _dbContext.Chores.Remove(chore);
        _dbContext.SaveChanges();
        return NoContent();
    }

[HttpPost("{id}/assign")]
[Authorize]
 public IActionResult AssignChore(int id, [FromQuery] int userId)
    {
        Chore chore = _dbContext.Chores.SingleOrDefault(c => c.Id == id);
        if (chore == null)
        {
            return NotFound();
        }
        ChoreAssignment assignment = new ChoreAssignment
        {
            UserProfileId = userId,
            ChoreId = id
        };
        _dbContext.ChoreAssignments.Add(assignment);
        _dbContext.SaveChanges();
        return NoContent();
    }

[HttpPost("{id}/unassign")]
[Authorize]

public IActionResult UnassignChore(int id, [FromQuery] int userId)
    {
       ChoreAssignment assignment = _dbContext.ChoreAssignments
       .SingleOrDefault(ca => ca.ChoreId == id && ca.UserProfileId == userId);
       if (assignment == null)
        {
            return NotFound();
        } 
    _dbContext.ChoreAssignments.Remove(assignment);
    _dbContext.SaveChanges();
    return NoContent();
    }
[HttpGet("assigned")]
[Authorize]
public IActionResult GetAssigned()
{
    var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    var userProfile = _dbContext.UserProfiles
        .FirstOrDefault(up => up.IdentityUserId == identityUserId);

    if (userProfile == null)
    {
        return NotFound();
    }

    var assignedChores = _dbContext.Chores
        .Include(c => c.ChoreCompletions)
        .Include(c => c.ChoreAssignments)
        .Where(c => c.ChoreAssignments.Any(ca => ca.UserProfileId == userProfile.Id))
        .Where(c => c.ChoreCompletions == null || c.ChoreCompletions.Count == 0 || 
                    c.ChoreCompletions.Max(cc => cc.CompletedOn).AddDays(c.ChoreFrequencyDays) < DateTime.Today)
        .ToList();

    return Ok(_mapper.Map<List<ChoreDto>>(assignedChores));
}



}