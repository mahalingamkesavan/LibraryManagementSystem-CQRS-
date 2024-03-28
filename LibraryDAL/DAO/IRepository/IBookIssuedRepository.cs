using LibraryUtil.Models;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.IRepository
{
    public interface IBookIssuedRepository:IGenericRepository<IssuedBook>
    {
       // public IssuedBookResponseDTO IssuedBookDetail(IssuedBook issuedBook);
    }
}
