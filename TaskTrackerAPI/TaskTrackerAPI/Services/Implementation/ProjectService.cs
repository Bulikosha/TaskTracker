using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services.Interfaces;
using TaskTrackerAPI.Repositories.Interfaces;

namespace TaskTrackerAPI.Services.Implementation;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;

    public ProjectService(IProjectRepository repository)
    {
        _repository = repository;
    }
    
    public async Task CreateAsync(ProjectDTO projectDTO)
    {
        Project project = new Project()
        {
            Id = projectDTO.Id,
            Name = projectDTO.Name,
            Priority = projectDTO.Priority,
            Tasks = new List<ProjectTask>(),
            Status = projectDTO.Status,
            StartDate = projectDTO.StartDate,
            CompletionDate = projectDTO.CompletionDate,
        };
        
        await _repository.CreateAsync(project);
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _repository.GetAllProjectsAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        return await _repository.GetProjectByIdAsync(id);
    }
    
    public async Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO)
    {
        return await _repository.UpdateProjectByIdAsync(id, projectDTO);
    }

    public async Task DeleteProjectByIdAsync(int id)
    {
        await _repository.DeleteProjectByIdAsync(id);
    }
}