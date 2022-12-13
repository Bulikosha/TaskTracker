using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services.Interfaces;

namespace TaskTrackerAPI.Controllers;

[Route("api/v1/projects")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectDTO projectDTO)
    {
        try
        {
            await _projectService.CreateAsync(projectDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpGet()]
    public async Task<ActionResult<List<Project>>> GetAllProjectsAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return projects;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{projectId:int}")]
    public async Task<ActionResult<Project>> GetProjectByIdAsync(int projectId)
    {
        try
        {
            var projects = await _projectService.GetProjectByIdAsync(projectId);
            
            return projects;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{projectId:int}")]
    public async Task<IActionResult> UpdateProjectByIdAsync(int projectId, ProjectDTO projectDTO)
    {
        try
        {
            await _projectService.UpdateProjectByIdAsync(projectId, projectDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return NoContent();
    }

    [HttpDelete("{projectId:int}")]
    public async Task<IActionResult> DeleteProjectByIdAsync(int projectId)
    {
        try
        {
            await _projectService.DeleteProjectByIdAsync(projectId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return NoContent();
    }
}