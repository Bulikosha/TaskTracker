using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.DTOs;

public class ProjectTaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProjectTaskStatus Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public int ProjectId { get; set; }
}