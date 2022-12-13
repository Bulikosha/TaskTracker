﻿using TaskTrackerAPI.Enums;

namespace TaskTrackerAPI.DTOs;

/*
 * We use DTO objects to interact with the client. Then DTO objects are mannually mapped to our entities. For this particular project automapper was not used.
 */
public class ProjectTaskDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProjectTaskStatus Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public int ProjectId { get; set; }
}