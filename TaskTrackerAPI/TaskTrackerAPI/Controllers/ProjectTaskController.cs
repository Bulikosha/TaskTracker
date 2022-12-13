using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services.Interfaces;

namespace TaskTrackerAPI.Controllers;

[Route("api/v1/tasks")]
[ApiController]
public class ProjectTaskController : ControllerBase
{
    private readonly IProjectTaskService _taskService;

    public ProjectTaskController(IProjectTaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTaskAsync([FromBody] ProjectTaskDTO taskDTO)
    {
        try
        {
            await _taskService.CreateAsync(taskDTO);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return NoContent();
    }

    [HttpGet()]
    public async Task<ActionResult<List<ProjectTask>>> GetAllTasksAsync()
    {
        var tasks = await _taskService.GetAllProjectTasksAsync();
        
        if (tasks == null)
        {
            return NotFound();
        }

        return tasks;
        
    }

    [HttpGet("{projectId:int}/tasks")]
    public async Task<ActionResult<List<ProjectTask>>> GetAllTasksByProjectIdAsync(int projectId)
    {
        var projects = await _taskService.GetAllProjectTasksByProjectIdAsync(projectId);

        if (projects == null)
        {
            return NotFound();
        }

        return projects;
    }

    [HttpGet("{taskId:int}")]
    public async Task<ActionResult<ProjectTask>> GetTaskByIdAsync(int taskId)
    {
        var task = await _taskService.GetProjectTaskByIdAsync(taskId);
        
        if (task == null)
        {
            BadRequest();
        }
        
        return task;
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTaskByIdAsync(int taskId, ProjectTaskDTO taskDto)
    {
        try
        {
            await _taskService.UpdateProjectTaskByIdAsync(taskId, taskDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return NoContent();
    }

    [HttpDelete("{taskId:int}")]
    public async Task<IActionResult> DeleteTaskByIdAsync(int taskId)
    {
        try
        {
            await _taskService.DeleteProjectTaskByIdAsync(taskId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return NoContent();
    }
}