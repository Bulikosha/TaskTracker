using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Repositories.Interfaces;
using TaskTrackerAPI.DataContext;

namespace TaskTrackerAPI.Repositories.Implementation;

public class ProjectTaskRepository : IProjectTaskRepository
{
    private readonly Context _dbContext;

    public ProjectTaskRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CreateAsync(ProjectTask task)
    {
        var projectFromDB = _dbContext.Projects.FirstOrDefault(p => p.Id == task.ProjectId);
        if (projectFromDB != null)
        {
            if (projectFromDB.Tasks == null)
            {
                projectFromDB.Tasks = new List<ProjectTask>();
            }
            
            projectFromDB.Tasks.Add(task);
        }

        _dbContext.Add(task);
        task.Id = _dbContext.SaveChanges();

        await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
    }

    public async Task<List<ProjectTask>> GetAllProjectTasksAsync()
    {
        return await _dbContext.Tasks.Where(t => true).ToListAsync();
    }

    public async Task<List<ProjectTask>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        var tasks = await _dbContext.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        return tasks;
    }

    public async Task<ProjectTask> GetProjectTaskByIdAsync(int id)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        return task != null ? task : throw new ArgumentNullException(nameof(task));
    }

    public async Task<ProjectTask> UpdateProjectTaskByIdAsync(int id, ProjectTaskDTO taskDTO)
    {
        var taskToUpdate = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (taskToUpdate == null) throw new ArgumentNullException(nameof(taskToUpdate));
        
        taskToUpdate.Name = taskDTO.Name;
        taskToUpdate.Priority = taskDTO.Priority;
        taskToUpdate.Status = taskDTO.Status;
        taskToUpdate.Description = taskDTO.Description;
        taskToUpdate.ProjectId = taskDTO.ProjectId;
        await _dbContext.SaveChangesAsync();
            
        return taskToUpdate;
    }

    public async Task DeleteProjectTaskByIdAsync(int id)
    {
        var taskToDelete = _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (taskToDelete != null) _dbContext.Remove(taskToDelete);
        await _dbContext.SaveChangesAsync();
    }
}