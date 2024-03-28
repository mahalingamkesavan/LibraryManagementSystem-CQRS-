using LibraryDAL.DAO.IRepository;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Repository
{
    public class PagiNationRepository<T, R> : IPagiNationRepository<T, R> where T : class
    {
        public PagiNationResponseDTO<T> GetPagiNation(List<T> source, PagiNationRequestDTO pagiNationInput)
        {
            var curentPage = pagiNationInput.PageNumber;
            var totalNoOfRecords=source.Count;
            var pageSize = pagiNationInput.PageSize;
            var results=source.Skip((pagiNationInput.PageNumber -1)*(pagiNationInput.PageSize))
                .Take(pagiNationInput.PageSize).ToList();
            throw new NotImplementedException();
        }
    }
}
