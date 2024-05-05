using TaskManagement.DTO_s.TaskDto;

namespace TaskManagement.DAL.Contracts
{
    public interface ITask:IBase<TaskDto, CreateTaskDto,EditTaskDto>
    {
    }
}
