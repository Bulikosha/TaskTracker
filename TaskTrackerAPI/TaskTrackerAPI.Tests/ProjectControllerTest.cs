using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskTrackerAPI.Controllers;
using TaskTrackerAPI.DTOs;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Services.Interfaces;

namespace TaskTrackerAPI.Tests;

public class ProjectControllerTest
{
    [Fact]
    public async Task Post_CreateProject_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);
        
        mockService.Setup(x => x.CreateAsync(It.IsAny<ProjectDTO>())).Verifiable();

        var result = await controller.CreateProjectAsync(new ProjectDTO());
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task Get_AllProjects_ReturnsListOfProjectsTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);

        mockService.Setup(x => x.GetAllProjectsAsync()).ReturnsAsync(new List<Project>());

        var result = await controller.GetAllProjectsAsync();
        Assert.IsAssignableFrom<ActionResult<List<Project>>>(result);
    }

    [Fact]
    public async Task Get_ProjectById_ReturnsProjectTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);

        mockService.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync(new Project());
        
        var result = await controller.GetProjectByIdAsync(1);
        Assert.IsAssignableFrom<ActionResult<Project>>(result);
    }

    [Fact]
    public async Task Put_UpdateProjectById_ReturnsBadRequestTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);

        mockService.Setup(x => x.UpdateProjectByIdAsync(It.IsAny<int>(),It.IsAny<ProjectDTO>())).ReturnsAsync(new Project());
        
        var result = await controller.UpdateProjectByIdAsync(1, new ProjectDTO());
        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task Put_UpdateProjectById_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);

        mockService.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync(new Project());
        mockService.Setup(x => x.UpdateProjectByIdAsync(It.IsAny<int>(),It.IsAny<ProjectDTO>())).ReturnsAsync(new Project());
        
        var result = await controller.UpdateProjectByIdAsync(0, new ProjectDTO());
        Assert.IsType<NoContentResult>(result);
    }
    
    [Fact]
    public async Task Delete_ProjectById_ReturnsNoContentTest()
    {
        var mockService = new Mock<IProjectService>();
        var controller = new ProjectController(mockService.Object);

        mockService.Setup(x => x.GetProjectByIdAsync(It.IsAny<int>())).ReturnsAsync(new Project());
        
        var result = await controller.DeleteProjectByIdAsync(1);
        Assert.IsType<NoContentResult>(result);
    }
}