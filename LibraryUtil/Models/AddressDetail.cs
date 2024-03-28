using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryUtil.Models
{
    public partial class AddressDetail
    {
        public int AddressId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]
        public virtual UserRegistration User { get; set; } = null!;
    }
}
