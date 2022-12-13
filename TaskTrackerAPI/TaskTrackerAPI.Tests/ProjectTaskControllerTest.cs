using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskTrackerAPI.Controllers;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services.Interfaces;

namespace TaskTrackerAPI.Tests;

public class ProjectTaskControllerTest
{
    [Fact]
    public async Task Post_CreateProjectTask_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);
        
        mockService.Setup(x => x.CreateAsync(It.IsAny<ProjectTaskDTO>())).Verifiable();

        var result = await controller.CreateTaskAsync(new ProjectTaskDTO());
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Get_AllProjectTasks_ReturnsListOfProjectTasksTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);

        mockService.Setup(x => x.GetAllProjectTasksAsync()).ReturnsAsync(new List<ProjectTask>());

        var result = await controller.GetAllTasksAsync();
        Assert.IsAssignableFrom<ActionResult<List<ProjectTask>>>(result);
    }

    [Fact]
    public async Task Get_ProjectTaskById_ReturnsProjectTaskTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);

        mockService.Setup(x => x.GetProjectTaskByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProjectTask());
        
        var result = await controller.GetTaskByIdAsync(1);
        Assert.IsAssignableFrom<ActionResult<ProjectTask>>(result);
    }

    [Fact]
    public async Task Put_UpdateProjectTaskById_ReturnsBadRequestTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);

        mockService.Setup(x => x.UpdateProjectTaskByIdAsync(It.IsAny<int>(),It.IsAny<ProjectTaskDTO>())).ReturnsAsync(new ProjectTask());
        
        var result = await controller.UpdateTaskByIdAsync(1, new ProjectTaskDTO());
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task Put_UpdateProjectTaskById_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);

        mockService.Setup(x => x.GetProjectTaskByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProjectTask());
        mockService.Setup(x => x.UpdateProjectTaskByIdAsync(It.IsAny<int>(),It.IsAny<ProjectTaskDTO>())).ReturnsAsync(new ProjectTask());
        
        var result = await controller.UpdateTaskByIdAsync(0, new ProjectTaskDTO());
        Assert.IsType<NoContentResult>(result);
    }
    
    [Fact]
    public async Task Delete_ProjectTaskById_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectTaskService>();
        var controller = new ProjectTaskController(mockService.Object);

        mockService.Setup(x => x.GetProjectTaskByIdAsync(It.IsAny<int>())).ReturnsAsync(new ProjectTask());
        
        var result = await controller.DeleteTaskByIdAsync(1);
        Assert.IsType<NoContentResult>(result);
    }
}