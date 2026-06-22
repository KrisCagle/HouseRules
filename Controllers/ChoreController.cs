using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HouseRules.Data;
using Microsoft.EntityFrameworkCore;
using HouseRules.Models;
using HouseRules.Models.DTOs;
using AutoMapper;

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
[Authorize]
public IActionResult Get()
{
    List<Chore> chores = _dbContext
        .Chores
        .ToList();
    List<ChoreDto> dtos = _mapper.Map<List<ChoreDto>>(chores);
    return Ok(dtos);
}



}