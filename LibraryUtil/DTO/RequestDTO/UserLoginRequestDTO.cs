using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.RequestDTO
{
    public class UserLoginRequestDTO
    {
        [Required(ErrorMessage ="Enter the Email ID")]
        [EmailAddress(ErrorMessage = "enter the valid Email ID")]
        public string? Email { get; set; }
        [Required]
        
        public string? Password { get; set; }
    }
}
