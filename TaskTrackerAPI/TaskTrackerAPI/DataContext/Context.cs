using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.Enums;
using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.DataContext;

public class Context : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ManyToOne relation is being configured (many tasks for one project)
        modelBuilder.Entity<ProjectTask>()
            .HasOne<Project>(task => task.Project)
            .WithMany(project => project.Tasks)
            .HasForeignKey(p => p.ProjectId);
        
        //For testing purposes the following initial data seeding is processed
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Name = "Build TEC",
                StartDate = new DateTime(2022, 12, 15).ToUniversalTime(),
                CompletionDate = new DateTime(2023, 12, 14).ToUniversalTime(),
                Status = ProjectStatus.NotStarted,
                Priority = 1
            });
        
        modelBuilder.Entity<ProjectTask>().HasData(
            new ProjectTask()
            {
                Id = 1,
                Name = "Prepare documents",
                Description = "For the purposes of TEC construction Project documents should be prepared",
                Status = ProjectTaskStatus.InProgress,
                Priority = 10,
                ProjectId = 1
            },
            new ProjectTask()
            {
                Id = 2,
                Name = "Buq equipments",
                Description = "Equipments in accordance with Project documentation should be purchased",
                Status = ProjectTaskStatus.ToDo,
                Priority = 5,
                ProjectId = 1
            });
    }
}