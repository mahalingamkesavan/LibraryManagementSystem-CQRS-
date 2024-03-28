using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class ReturnDurationResponseDTO
    {
        public DateTime PurchaseDate { get; set; }
        public DateTime LastDate { get; set; }
        public string? BookName { get; set; }
        public int? HoldingDays { get; set; }
        public int? RemainingDays { get; set; }

    }
}
