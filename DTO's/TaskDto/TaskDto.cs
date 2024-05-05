using TaskManagement.Enums;
using TaskManagement.Models;

namespace TaskManagement.DTO_s.TaskDto
{
    public record class TaskDto(string title,string description,Status Status, DateTime dueDate, User AssignedUser);
}
