using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BlogApplication.Enums;

namespace BlogApplication.Models
{
    public class Blog
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }
        [Required]
        public required string Body { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public Status Status { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}