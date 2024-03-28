using LibraryUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class AllBookTypeDTO
    {
       public IEnumerable<BookType>? bookTypes { get; set; }
    }
}
