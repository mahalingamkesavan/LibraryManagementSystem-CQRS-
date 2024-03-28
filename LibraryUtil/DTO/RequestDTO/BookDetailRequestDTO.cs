using System.ComponentModel.DataAnnotations;


namespace LibraryUtil.DTO.RequestDTO
{
    public class BookDetailRequestDTO
    {
        [Required(ErrorMessage = "Enter the Book Title")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Book Title must be 3 to 50 character")]
        public string? BookName { get; set; }

        [Required(ErrorMessage = "Enter the Type Of Book ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Type Of Book must be 3 to 50 character")]
        public string? TypeOfBook { get; set; }

        [Required(ErrorMessage = "Enter the Author ")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Author must be 3 to 50 character")]
        public string? AuthorName { get; set; }
        public int BookVolume { get; set; }

    }
}
