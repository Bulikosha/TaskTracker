using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
    
    //Collection property for association purposes (with ProjectTask)
    public ICollection<ProjectTask> Tasks { get; set; }
}