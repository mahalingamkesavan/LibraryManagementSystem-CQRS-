using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.IRepository
{
    public interface IPagiNationRepository<T,R> where T:class 
    {
        PagiNationResponseDTO<T> GetPagiNation(List<T> source,PagiNationRequestDTO pagiNationInput);

    }
}
