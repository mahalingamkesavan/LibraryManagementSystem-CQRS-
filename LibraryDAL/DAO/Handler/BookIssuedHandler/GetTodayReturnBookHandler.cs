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
    internal class GetTodayReturnBookHandler : IRequestHandler<GetTodayReturnBookQueries, TodaysReturnBookListDTO>
    {
        private LibraryDbContext dbContext;
        public GetTodayReturnBookHandler(LibraryDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<TodaysReturnBookListDTO> Handle(GetTodayReturnBookQueries request, CancellationToken cancellationToken)
        {
            TodaysReturnBookListDTO returnBookList = new TodaysReturnBookListDTO();
            var date= DateTime.Now.Date;
            returnBookList.TodaysReturns = dbContext.IssuedBooks.Where(x=>x.LateDate.Month==date.Month && x.LateDate.Day==date.Day)
                .Select(x => new TodaysReturnBookDTO
            {
                BookName = x.BooK.BookName,
                PurchaseDay = x.CreatedDate,
                EmailID = x.User.Email,
                Name = x.User.Name,
                UserID =x.UserId
            }).ToList() ;
            return returnBookList;
        }
    }
}
