using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Repositories.Interfaces;

public interface IProjectRepository
{
    Task CreateAsync(Project project);
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO project);
    Task DeleteProjectByIdAsync(int id);
}