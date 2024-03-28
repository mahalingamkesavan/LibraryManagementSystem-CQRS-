using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class TodaysReturnBookDTO
    {
        public string? BookName { get; set; }
        public int UserID  { get; set; }
        public string? Name { get; set; }
        public DateTime? PurchaseDay { get; set; }
        public string? EmailID { get; set;}
    }
}
