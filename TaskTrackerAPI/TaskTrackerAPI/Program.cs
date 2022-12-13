using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.DataContext;
using TaskTrackerAPI.Repositories.Implementation;
using TaskTrackerAPI.Repositories.Interfaces;
using TaskTrackerAPI.Services.Implementation;
using TaskTrackerAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); //for enum values (e.g. Project and Project Task Statuses)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Declaring dependancies
builder.Services.AddScoped<IProjectRepository, ProjectRepository > ();
builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository > ();
builder.Services.AddScoped<IProjectService, ProjectService > ();
builder.Services.AddScoped<IProjectTaskService, ProjectTaskService > ();

builder.Services.AddDbContext<Context>(opts =>
{
    //Connection to DB via "Default" connection strings. Connection string is taken from appsettings.json
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();