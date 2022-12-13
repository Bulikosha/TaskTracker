using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services.Interfaces;

public interface IProjectTaskService
{
    Task CreateAsync(ProjectTaskDTO taskDTO);
    Task<List<ProjectTask>> GetAllProjectTasksAsync();
    Task<List<ProjectTask>> GetAllProjectTasksByProjectIdAsync(int projectId);
    Task<ProjectTask> GetProjectTaskByIdAsync(int id);
    Task<ProjectTask> UpdateProjectTaskByIdAsync(int id, ProjectTaskDTO taskDTO);
    Task DeleteProjectTaskByIdAsync(int id);
}