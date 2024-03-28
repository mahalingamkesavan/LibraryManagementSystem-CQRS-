using LibraryDAL.Context;
using LibraryDAL.DAO.Queries.BookIssuedQueries;
using LibraryUtil.DTO.ResponseDTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookIssuedHandler
{
    internal class GetReturnDurationIssuedBookHandler : IRequestHandler<GetReturnDurationIssuedBookQueries,List<ReturnDurationResponseDTO>>
    {
        private LibraryDbContext dbContext;
        public GetReturnDurationIssuedBookHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ReturnDurationResponseDTO>> Handle(GetReturnDurationIssuedBookQueries request, CancellationToken cancellationToken)
        {
            var returnBook =await  dbContext.IssuedBooks.Where(x => x.UserId == request.UserId).
                 Select(x => new ReturnDurationResponseDTO()
                 {
                     BookName = x.BooK.BookName,
                     LastDate = x.LateDate,
                     PurchaseDate = (DateTime)x.CreatedDate
                 }).ToListAsync();
            return returnBook;
        }
    }
}
