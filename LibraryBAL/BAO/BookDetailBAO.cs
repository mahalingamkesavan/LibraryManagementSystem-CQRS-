using AutoMapper;
using LibraryBAL.Interface;
using LibraryDAL.DAO.Command.BookDetailCommand;
using LibraryDAL.DAO.Queries.BookDetailQueries;
using LibraryDAL.DAO.Queries.BookIssuedQueries;
using LibraryDAL.DAO.Queries.BookTypeQueries;  
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using MediatR;
using System.Net;

namespace LibraryBAL.BAO
{
    public class BookDetailBAO : IBookDetailBAO
    {
      
        private readonly IMediator mediator;
        IMapper mapper;
        public BookDetailBAO(IMapper mapper, IMediator mediator)
        {
           
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<ResultResponseDTO> AddBook(BookDetailRequestDTO bookDetail)
        {
            var bookData=mapper.Map<BookDetail>(bookDetail);
            bookData.CreatedDate = DateTime.Now;
            bookData.CreatedBy = "Admin";
           bool IsExcute =await mediator.Send(new CreateBookDetailCommend(bookData));
            return ResponseMessageDetail.resultResponse(IsExcute, Constants.Inserted);
        }

        public async Task<ResultResponseDTO> DeleteBook(int id)
        {
            bool IsExcute = await mediator.Send(new DeleteBookDetailCommand(id));
            return ResponseMessageDetail.resultResponse(IsExcute,Constants.Deleted);
        }

        public async Task<List<BookDetail>> GetAllBook()
        {
            var result = await mediator.Send(new GetBookDetailListQueries());
            return result;
        }
        public Task<PagiNationResponseDTO<BookDetail>> GetAllBookPagiNation(PagiNationRequestDTO pagiNation)
        {
            var result =  mediator.Send(new GetBookPagiNationQueries(pagiNation));
            return result;
        }

        public async Task<BookDetail> GetBookDetail(int bookID)
        {
            var result = await mediator.Send(new GetBookDetailByIdQueries(bookID));
            return result;
        }

        public async Task<ResultResponseDTO> UpdateBook(UpdateBookDetailRequestDTO updatedBook)
        {
            var data=mapper.Map<BookDetail>(updatedBook);
            data.UpdatedDate = DateTime.Now;
            bool IsExcute =await mediator.Send(new UpdateBookDetailCommand(data));
            return ResponseMessageDetail.resultResponse(IsExcute,Constants.Updated);
        }
        public async Task<AllBookTypeDTO> AllBookType()
        {
            AllBookTypeDTO bookes = new();
            bookes.bookTypes = await mediator.Send(new GetBookTypeListQueries());
            return bookes;
        }

       
    }
}
