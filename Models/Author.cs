using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public  string Bio { get; set; } = default!;

        public IEnumerable<Blog>? Blogs { get; set; }
    }
}