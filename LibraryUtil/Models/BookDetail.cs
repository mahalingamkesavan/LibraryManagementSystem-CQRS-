using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryUtil.Models
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
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]

        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}
