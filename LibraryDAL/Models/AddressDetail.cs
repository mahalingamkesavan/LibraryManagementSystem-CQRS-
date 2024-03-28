using System;
using System.Collections.Generic;

namespace LibraryDAL.Models
{
    public partial class AddressDetail
    {
        public int AddressId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int UserId { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual UserRegistration User { get; set; } = null!;
    }
}
