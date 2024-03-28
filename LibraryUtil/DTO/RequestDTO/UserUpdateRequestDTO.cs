using System.ComponentModel.DataAnnotations;


namespace LibraryUtil.DTO.RequestDTO
{
    public class UserUpdateRequestDTO : UserRegistrationRequestDTO
    {
        [Required(ErrorMessage = "Enter the Valid Id")]
        public int UserId { get; set; }
    }
}
