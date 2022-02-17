using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class UserInfo
    {
        [Column("UserInfo")]            // name of column for Id
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Username is 60 characters.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "The password is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the password is 60 characters")]
        public string? password { get; set; }

        public ICollection<Task>? Tasks { get; set; }
    }

}
