using TaskManagement.Enums;
using TaskManagement.Models;

namespace TaskManagement.DTO_s.TaskDto
{
    public record class EditTaskDto(int Id, string title, string Description, User assigneduser, DateTime DateTime, Status status);
}
