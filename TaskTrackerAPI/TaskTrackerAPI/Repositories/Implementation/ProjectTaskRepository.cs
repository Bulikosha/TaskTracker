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
        // var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
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
        var newTask = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        if (newTask == null) throw new ArgumentNullException(nameof(newTask));
        
        newTask.Name = taskDTO.Name;
        newTask.Priority = taskDTO.Priority;
        newTask.Status = taskDTO.Status;
        newTask.Description = taskDTO.Description;
        newTask.ProjectId = taskDTO.ProjectId;
        await _dbContext.SaveChangesAsync();
            
        return newTask;
    }

    public async Task DeleteProjectTaskByIdAsync(int id)
    {
        var taskToDelete = _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
        if (taskToDelete != null) _dbContext.Remove(taskToDelete);
        await _dbContext.SaveChangesAsync();
    }
}