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
    internal class GetBookIssuedByUserIdHandler : IRequestHandler<GetBookIssuedByUserIdQueries, List<IssuedBookResponseDTO>>
    {
        private readonly LibraryDbContext dbContext;

        public GetBookIssuedByUserIdHandler(LibraryDbContext unitOfWork)
        {
            this.dbContext = unitOfWork;
        }
        public Task<List<IssuedBookResponseDTO>> Handle(GetBookIssuedByUserIdQueries request, CancellationToken cancellationToken)
        {
            var data = dbContext.IssuedBooks.Where(x => x.UserId == request.UserID).Select(
                x => new IssuedBookResponseDTO
                {
                    UserId = x.User.UserId,
                    BookId = x.BooK.BookId,
                    BookIssuedID= x.IssuedBookId,
                    AuthorName = x.BooK.AuthorName,
                    BookName = x.BooK.BookName,
                    FirstName = x.User.Name,
                    EmailId = x.User.Email,
                    PhoneNumber = x.User.PhoneNumber,
                    BookSubmitDate = x.LateDate,
                }).ToList();
            return Task.FromResult(data);
        }
    }
}
