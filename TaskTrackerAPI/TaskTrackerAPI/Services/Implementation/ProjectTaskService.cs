using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Repositories.Interfaces;
using TaskTrackerAPI.Services.Interfaces;

namespace TaskTrackerAPI.Services.Implementation;

public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskRepository _repository;

    public ProjectTaskService(IProjectTaskRepository repository)
    {
        _repository = repository;
    }
    
    public async Task CreateAsync(ProjectTaskDTO taskDTO)
    {
        ProjectTask task = new ProjectTask()
        {
            Id = taskDTO.Id,
            Name = taskDTO.Name,
            Status = taskDTO.Status,
            Description = taskDTO.Description,
            Priority = taskDTO.Priority,
            ProjectId = taskDTO.ProjectId
        };
        await _repository.CreateAsync(task);
    }

    public async Task<List<ProjectTask>> GetAllProjectTasksAsync()
    {
        return await _repository.GetAllProjectTasksAsync();
    }

    public async Task<List<ProjectTask>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        return await _repository.GetAllProjectTasksByProjectIdAsync(projectId);
    }

    public async Task<ProjectTask> GetProjectTaskByIdAsync(int id)
    {
        return await _repository.GetProjectTaskByIdAsync(id);
    }

    public async Task<ProjectTask> UpdateProjectTaskByIdAsync(int id, ProjectTaskDTO taskDTO)
    {
        return await _repository.UpdateProjectTaskByIdAsync(id, taskDTO);
    }

    public async Task DeleteProjectTaskByIdAsync(int id)
    {
        await _repository.DeleteProjectTaskByIdAsync(id);
    }
}