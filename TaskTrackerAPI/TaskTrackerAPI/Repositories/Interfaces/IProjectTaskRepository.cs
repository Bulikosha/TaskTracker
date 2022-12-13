using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Repositories.Interfaces;

public interface IProjectTaskRepository
{
    Task CreateAsync(ProjectTask task);
    Task<List<ProjectTask>> GetAllProjectTasksAsync();
    Task<List<ProjectTask>> GetAllProjectTasksByProjectIdAsync(int projectId);
    Task<ProjectTask> GetProjectTaskByIdAsync(int id);
    Task<ProjectTask> UpdateProjectTaskByIdAsync(int id, ProjectTaskDTO task);
    Task DeleteProjectTaskByIdAsync(int id);
}