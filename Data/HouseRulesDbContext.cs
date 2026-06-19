using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Data;
public class HouseRulesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }

    public HouseRulesDbContext(DbContextOptions<HouseRulesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
{
    new IdentityUser
    {
        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
        UserName = "Administrator",
        Email = "admina@strator.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
    },
    new IdentityUser
    {
        Id = "a8f0e1c2-1234-4b56-89ab-cdef01234567",
        UserName = "JaneMechanic",
        Email = "jane@biancasbikes.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
    },
    new IdentityUser
    {
        Id = "b9e1f2d3-5678-4c67-90bc-ef0123456789",
        UserName = "BobWrench",
        Email = "bob@biancasbikes.comx",
        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
    }
});

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
{
    new UserProfile
    {
        Id = 1,
        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
        FirstName = "Admina",
        LastName = "Strator",
        Address = "101 Main Street",
    },
    new UserProfile
    {
        Id = 3,
        IdentityUserId = "a8f0e1c2-1234-4b56-89ab-cdef01234567",
        FirstName = "Jane",
        LastName = "Mechanic",
        Address = "202 Bike Lane",
    },
    new UserProfile
    {
        Id = 4,
        IdentityUserId = "b9e1f2d3-5678-4c67-90bc-ef0123456789",
        FirstName = "Bob",
        LastName = "Wrench",
        Address = "303 Gear Street",
    }
});
}}  