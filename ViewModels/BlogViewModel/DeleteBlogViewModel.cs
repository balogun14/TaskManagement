using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.ViewModels.BlogViewModel
{
    public class DeleteBlogViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}