using System;
using System.Collections.Generic;

namespace LibraryDAL.Models
{
    public partial class BookDetail
    {
        public BookDetail()
        {
            IssuedBooks = new HashSet<IssuedBook>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string? AuthorName { get; set; }
        public string TypeOfBook { get; set; } = null!;
        public int BookVolume { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}
