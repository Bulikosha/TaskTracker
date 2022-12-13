using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.DataContext;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Repositories.Interfaces;

namespace TaskTrackerAPI.Repositories.Implementation;

public class ProjectRepository : IProjectRepository
{
    private readonly Context _dbContext;

    public ProjectRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CreateAsync(Project projectDTO)
    {
        _dbContext.Add(projectDTO);
        projectDTO.Id = await _dbContext.SaveChangesAsync();

        await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectDTO.Id);
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _dbContext.Projects.Where(p => true).ToListAsync();
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        return project != null ? project : throw new ArgumentNullException(nameof(project));
    }

    public async Task<Project> UpdateProjectByIdAsync(int id, ProjectDTO projectDTO)
    {
        var projectToBeUpdated = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);

        if (projectToBeUpdated == null) throw new ArgumentNullException(nameof(projectToBeUpdated));
        
        projectToBeUpdated.Name = projectDTO.Name;
        projectToBeUpdated.Priority = projectDTO.Priority;
        projectToBeUpdated.Status = projectDTO.Status;
        projectToBeUpdated.StartDate = projectDTO.StartDate;
        projectToBeUpdated.CompletionDate = projectDTO.CompletionDate;
        await _dbContext.SaveChangesAsync();
            
        return projectToBeUpdated;
    }

    public async Task DeleteProjectByIdAsync(int id)
    {
        var projectToDelete = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        if (projectToDelete != null) _dbContext.Remove(projectToDelete);
        await _dbContext.SaveChangesAsync();
    }
}