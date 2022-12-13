using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.DTOs;
/*
 * We use DTO objects to interact with the client. Then DTO objects are mannually mapped to our entities. For this particular project automapper was not used.
 */
public class ProjectDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
}