using System.ComponentModel;
using TaskManagement.Enums;

namespace TaskManagement.Models
{
    public class TODO
    {
        public int TaskId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; }
        [DisplayName("Due Date")]

        public DateTime DueDate { get; set; }
        [DisplayName("Assigned User")]
        public required User AssignedUser { get; set; }
    }
}
