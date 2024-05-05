namespace TaskManagement.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
