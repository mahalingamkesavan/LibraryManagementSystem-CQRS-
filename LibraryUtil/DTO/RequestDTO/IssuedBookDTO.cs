using System.ComponentModel.DataAnnotations;


namespace LibraryUtil.DTO.RequestDTO
{
    public class IssuedBookDTO
    {
        [Required(ErrorMessage = "Enter the Book id")]
        public int BooKid { get; set; }
        [Required(ErrorMessage = "Enter the User Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Enter the Name")]
        public string? Name { get; set; }
    }
}
