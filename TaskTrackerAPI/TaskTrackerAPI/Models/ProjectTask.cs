using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.Models;

public class ProjectTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public ProjectTaskStatus Status { get; set; }
    
    [ForeignKey(nameof(Project))]
    public int ProjectId { get; set; }
    
    [JsonIgnore] //To ignore circular references between our entities
    public Project Project { get; set; }

}