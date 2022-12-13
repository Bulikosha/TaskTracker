using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Services.Interfaces;

public interface IProjectService
{
    Task CreateAsync(ProjectDTO projectDTO);
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(int id);
    Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO);
    Task DeleteProjectByIdAsync(int id);
}