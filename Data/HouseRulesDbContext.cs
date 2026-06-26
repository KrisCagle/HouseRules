using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HouseRules.Models;
using Microsoft.AspNetCore.Identity;

namespace HouseRules.Data;
public class HouseRulesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Chore> Chores { get; set; }
    public DbSet<ChoreAssignment> ChoreAssignments { get; set; }
    public DbSet<ChoreCompletion> ChoreCompletions { get; set; }

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
        Email = "admina@strator.comx",
    },
    new UserProfile
    {
        Id = 3,
        IdentityUserId = "a8f0e1c2-1234-4b56-89ab-cdef01234567",
        FirstName = "Jane",
        LastName = "Mechanic",
        Address = "202 Bike Lane",
        Email = "jane@biancasbikes.comx",
    },
    new UserProfile
    {
        Id = 4,
        IdentityUserId = "b9e1f2d3-5678-4c67-90bc-ef0123456789",
        FirstName = "Bob",
        LastName = "Wrench",
        Address = "303 Gear Street",
        Email = "bob@biancasbikes.comx",
    }
});

modelBuilder.Entity<Chore>().HasData(new Chore[]
{
    new Chore
    {
        Id = 1,
        Name="Mow The Lawn",
        Difficulty= 3,
        ChoreFrequencyDays= 14
    },
    new Chore
    {
        Id= 2,
        Name="Wash Dishes",
        Difficulty=2,
        ChoreFrequencyDays=2
    },
    new Chore
    {
        Id = 3,
        Name ="Wash the Car",
        Difficulty=3,
        ChoreFrequencyDays= 30
    },
    new Chore
    {
        Id= 4,
        Name="Walk the Dog",
        Difficulty=1,
        ChoreFrequencyDays=1
    },
    new Chore
    {
        Id = 5,
        Name ="Clean Room",
        Difficulty = 5,
        ChoreFrequencyDays = 12
    }
});

modelBuilder.Entity<ChoreAssignment>().HasData(new ChoreAssignment[]
{
    new ChoreAssignment
    {
        Id = 1,
        UserProfileId = 1,
        ChoreId = 1
    },
    new ChoreAssignment
    {
        Id = 2,
        UserProfileId = 1,
        ChoreId= 4
    }
});

modelBuilder.Entity<ChoreCompletion>().HasData(new ChoreCompletion[]
{
   new ChoreCompletion
    { 
        Id=1,
        UserProfileId = 1,
        ChoreId = 1,
        CompletedOn = new DateTime(2026,9,23)
    },
   new ChoreCompletion
   {
       Id =2,
       UserProfileId= 1,
       ChoreId = 3,
       CompletedOn = new DateTime(2026,4,19)
   }
});

}}  