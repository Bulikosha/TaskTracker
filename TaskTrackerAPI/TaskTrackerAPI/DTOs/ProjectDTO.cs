using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.DTOs;

public class ProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
}