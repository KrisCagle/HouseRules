using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRules.Models;

public class Chore
{
    public int Id { get; set; }
    
    [MaxLength(100, ErrorMessage = "Chore names must be 100 characters or less")]
    public string Name { get; set; }
    
    [Range(1, 5, ErrorMessage = "Difficulty must be between 1 and 5")]
    public int Difficulty { get; set; }
    
    [Range(1, 14, ErrorMessage = "Chore frequency must be between 1 and 14 days")]
    public int ChoreFrequencyDays { get; set; }
    
    public List<ChoreAssignment> ChoreAssignments { get; set; }
    public List<ChoreCompletion> ChoreCompletions { get; set; }

    [NotMapped]
    public bool IsOverdue
    {
        get
        {
            // If no completions, it's overdue
            if (ChoreCompletions == null || ChoreCompletions.Count == 0)
            {
                return true;
            }

            // Get the most recent completion
            var mostRecentCompletion = ChoreCompletions.Max(cc => cc.CompletedOn);

            // Check if it was completed more than ChoreFrequencyDays ago
            var dueDate = mostRecentCompletion.AddDays(ChoreFrequencyDays);
            return dueDate < DateTime.Today;
        }
    }
}