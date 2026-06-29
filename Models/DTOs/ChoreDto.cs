using System.ComponentModel.DataAnnotations;

namespace HouseRules.Models.DTOs;

public class ChoreDto
{
    public int Id { get; set; }
    
    [MaxLength(100, ErrorMessage = "Chore names must be 100 characters or less")]
    public string Name { get; set; }
    
    [Range(1, 5, ErrorMessage = "Difficulty must be between 1 and 5")]
    public int Difficulty { get; set; }
    
    [Range(1, 14, ErrorMessage = "Chore frequency must be between 1 and 14 days")]
    public int ChoreFrequencyDays { get; set; }

    public bool IsOverdue { get; set; }
}