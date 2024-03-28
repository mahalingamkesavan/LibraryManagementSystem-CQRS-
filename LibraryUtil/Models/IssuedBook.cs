using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryUtil.Models
{
    public partial class IssuedBook
    {
        public int IssuedBookId { get; set; }
        public int BooKid { get; set; }
        public int UserId { get; set; }
        public DateTime LateDate { get; set; }
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [JsonIgnore]
        public virtual BookDetail BooK { get; set; } = null!;
        [JsonIgnore]
        public virtual UserRegistration User { get; set; } = null!;
    }
}
