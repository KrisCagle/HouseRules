using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRules.Data;
using HouseRules.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace HouseRules.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private HouseRulesDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserProfileController(HouseRulesDbContext context, IMapper mapper)
    {
        _dbContext = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        List<UserProfile> profiles = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .ToList();

        List<UserProfileDTO> dtos = _mapper.Map<List<UserProfileDTO>>(profiles);

        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        UserProfile userProfile = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Include(up => up.ChoreAssignments)
                .ThenInclude(ca => ca.Chore)
            .Include(up => up.ChoreCompletions)
                .ThenInclude(cc => cc.Chore)
            .SingleOrDefault(up => up.Id == id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<UserProfileDTO>(userProfile));
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        List<UserProfile> profiles = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .ToList();

        List<UserProfileDTO> dtos = _mapper.Map<List<UserProfileDTO>>(profiles);

        foreach (UserProfileDTO dto in dtos)
        {
            dto.Roles = _dbContext.UserRoles
                .Where(ur => ur.UserId == dto.IdentityUserId)
                .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
                .ToList();
        }

        return Ok(dtos);
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(string id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = id
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(string id)
    {
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");
        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == id);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }
}