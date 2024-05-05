using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TaskManagement.DAL.Contracts;
using TaskManagement.Data;
using TaskManagement.DTO_s.TaskDto;
using TaskManagement.Enums;
using TaskManagement.Models;

namespace TaskManagement.DAL.Repository
{
    public class TaskRepository : ITask
    {
        private readonly ApplicationDbContext appDbContext;
        public TaskRepository(ApplicationDbContext appDb)
        {
            this.appDbContext = appDb;   
        }
        public async Task Create(CreateTaskDto createEntity)
        {
            var TaskToAdd = new TODO()
            {
                AssignedUser = createEntity.assigneduser,
                Description = createEntity.Description,
                DueDate = createEntity.dueDate,
                Status = createEntity.Status,
                Title = createEntity.title,
                TaskId = appDbContext.Tasks.GetHashCode(),
            };
            await appDbContext.AddAsync(TaskToAdd);
            await appDbContext.SaveChangesAsync();
        }

        

        public async Task<bool> Delete(int id)
        {
            var FoundTask = await appDbContext.Tasks.Where(e => e.TaskId == id).ExecuteDeleteAsync();
            return FoundTask != 0;
        }

        public async Task<IEnumerable<TaskDto>?> GetAll()
        {
            var FoundTask = await appDbContext.Tasks.Include(e=> e.AssignedUser).AsNoTracking().ToListAsync();
            var TaskListDto = FoundTask.Select(e => new TaskDto(
                title: e.Title,
                AssignedUser: e.AssignedUser,
                description: e.Description,
                dueDate: e.DueDate,
                Status: e.Status)) ;
            return TaskListDto;
        }

        public async Task<TaskDto?> GetById(int Id)
        {
            var Find = await appDbContext.Tasks.Include(e=> e.AssignedUser).FirstOrDefaultAsync(e => e.TaskId == Id);
            var TaskFound = new TaskDto(title: Find!.Title, description: Find.Description, Status: Find.Status, dueDate: Find.DueDate, AssignedUser: Find.AssignedUser);
            if (TaskFound is not null)
            {
                return TaskFound;
            }
            return null;
        }

        public Task<bool> Update(EditTaskDto editEntity)
        {
            var FoundTask = GetById(editEntity.Id);
            if (FoundTask is not null)
            {
                FoundTask.Status = editEntity.status;

            }
        }
    }
}
