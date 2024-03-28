using LibraryUtil.Models;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL.Interface
{
    public interface IBookIssuedBAL
    {
        public Task<ResultResponseDTO> AddIssuedBookDetail(IssuedBookDTO issuedBook);
        public Task<ResultResponseDTO> ReturnIssuedBookDetail(int issuedBookID);
        public  Task<IssuedBookResponseDTO> GetIssuedBookDetail(int issuedBookID);
        public Task<IssuedBookListResponseDTO> GetBookIssuedByUserId(int UserId);
        public  Task<IssuedBookListResponseDTO> GetALLIssuedBook();
        public Task<ListReturnDurationResponseDTO> GetReturnDuration(int UserId);
        public Task<TodaysReturnBookListDTO> GetTodaysReturnBookList();
    }
}
