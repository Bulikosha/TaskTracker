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
        try
        {
            var tasks = await _taskService.GetAllProjectTasksAsync();
            return tasks;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{projectId:int}/tasks")]
    public async Task<ActionResult<List<ProjectTask>>> GetAllTasksByProjectIdAsync(int projectId)
    {
        try
        {
            var projects = await _taskService.GetAllProjectTasksByProjectIdAsync(projectId);
            
            return projects;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{taskId:int}")]
    public async Task<ActionResult<ProjectTask>> GetTaskByIdAsync(int taskId)
    {
        try
        {
            var task = await _taskService.GetProjectTaskByIdAsync(taskId);
            return task;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTaskByIdAsync(int taskId, ProjectTaskDTO taskDto)
    {
        if (taskId != taskDto.Id) //Check if id and task id are equal
        {
            return BadRequest();
        }
        
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