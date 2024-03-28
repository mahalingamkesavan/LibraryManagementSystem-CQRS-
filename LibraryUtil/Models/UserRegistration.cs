using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryUtil.Models
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
        [JsonIgnore]
        public bool? Notify { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; } = null!;
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]

        public virtual ICollection<AddressDetail> AddressDetails { get; set; }
        [JsonIgnore]
        public virtual ICollection<IssuedBook> IssuedBooks { get; set; }
    }
}   
