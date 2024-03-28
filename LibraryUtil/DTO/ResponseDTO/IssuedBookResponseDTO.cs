using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class IssuedBookResponseDTO
    {
        public string? BookName { get; set; }
        public int? BookIssuedID { get; set; }
        public int? BookId { get; set; }
        public int? BookVolume { get; set; }
        public string? AuthorName { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? EmailId { get; set; }
        public string? PhoneNumber { get; set; } 
        public DateTime? BookSubmitDate { get; set; }
    }
}
