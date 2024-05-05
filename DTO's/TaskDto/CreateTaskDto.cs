using System.ComponentModel.DataAnnotations;
using TaskManagement.Enums;
using TaskManagement.Models;

namespace TaskManagement.DTO_s.TaskDto
{
    public record class CreateTaskDto(int Id, string title, string Description, User assigneduser, DateTime dueDate, Status Status);
}
