using System.ComponentModel.DataAnnotations;


namespace LibraryUtil.DTO.RequestDTO
{
    public class UserRegistrationRequestDTO
    {
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3 to 50 character")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Enter the valid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Password number should be 10 character")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number should be 10 character")]
        [Phone(ErrorMessage = "Enter the Valid PhoneNumber")]
        public string? PhoneNumber { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Role { get; set; }
    }
}
