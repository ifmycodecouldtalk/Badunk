using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Task
    {
        [Column("Tasks")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Name of the task must be set.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Task Name is 100 characters.")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Task description is a required field.")]
        [MaxLength(300, ErrorMessage = "Maximum length for the description is 300 characters.")]
        public string? Description { get; set; }


        [ForeignKey(nameof(UserInfo))]
        public Guid UserId { get; set; }
        public UserInfo? UserInfo { get; set; }
    }

}
