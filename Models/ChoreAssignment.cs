namespace HouseRules.Models;

public class ChoreAssignmment
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ChoreId { get; set; } 

    public Chore Chore {get; set; }
}