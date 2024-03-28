using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.RequestDTO
{
    public class UserApprovelRequestDTO
    {
        public int UserId { get; set; }
        public string? ApprovedBy { get; set; }
    }
}
