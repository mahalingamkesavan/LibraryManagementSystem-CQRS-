using System;
using System.Collections.Generic;

namespace LibraryDAL.Models
{
    public partial class IssuedBook
    {
        public int IssuedBookId { get; set; }
        public int BooKid { get; set; }
        public int UserId { get; set; }
        public DateTime LateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual BookDetail BooK { get; set; } = null!;
        public virtual UserRegistration User { get; set; } = null!;
    }
}
