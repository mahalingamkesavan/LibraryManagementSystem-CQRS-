using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryUtil.Models
{
    public partial class BookType
    {
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; } = null!;
        [JsonIgnore]
        public string? CreatedBy { get; set; }
        [JsonIgnore]
        public string? UpdatedBy { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
    }
}
