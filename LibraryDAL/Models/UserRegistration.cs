using System;
using System.Collections.Generic;

namespace LibraryDAL.Models
{
    public partial class UserRegistration
    {
        public UserRegistration()
        {
            AddressDetails = new HashSet<AddressDetail>();
            IssuedBooks = new HashSet<IssuedBook>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string UserStatus { get; set; } = null!;
        public string? ApprovedBy { get; set; }
        public bool? Notify { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}
