
using LibraryUtil.Models;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;


namespace LibraryBAL.Interface
{
    public interface IBookDetailBAO
    {
        public Task<ResultResponseDTO> AddBook(BookDetailRequestDTO bookDetail);
        public Task<ResultResponseDTO> UpdateBook(UpdateBookDetailRequestDTO updatedBook);
        public Task<ResultResponseDTO> DeleteBook(int id);
        public Task<BookDetail> GetBookDetail(int bookID);
        public Task<List<BookDetail>> GetAllBook();
        public Task<PagiNationResponseDTO<BookDetail>> GetAllBookPagiNation(PagiNationRequestDTO pagiNation);
        public  Task<AllBookTypeDTO> AllBookType();
    }
}
