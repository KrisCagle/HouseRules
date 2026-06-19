using HouseRules.Models.DTOs;

namespace HouseRules.Models;

public class ChoreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int ChoreFrequencyDays { get; set; }
    public List<ChoreCompletion> ChoreCompletions { get; set; }
}