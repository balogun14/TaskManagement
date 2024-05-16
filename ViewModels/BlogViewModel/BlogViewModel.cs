using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication.ViewModels.BlogViewModel
{
    public class BlogViewModel
    {
        public required string Name { get; set; }
        public required string  Body { get; set; }
        [DisplayName("Date Published")]
        public DateTime dateTime { get; set; }
        [DisplayName("Written By")]
        public required string AuthorName { get; set; }
    }
}