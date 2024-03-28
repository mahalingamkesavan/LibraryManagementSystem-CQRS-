using System;
using System.Collections.Generic;

namespace LibraryDAL.Models
{
    public partial class BookType
    {
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
