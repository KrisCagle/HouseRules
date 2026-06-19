namespace HouseRules.Models.DTOs;

public class ChoreCompletionDto
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ChoreId { get; set; }
    public DateTime CompletedOn { get; set; } 
}