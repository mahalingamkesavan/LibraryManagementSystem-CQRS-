using LibraryDAL.Context;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.BookIssuedQueries;
using LibraryUtil.Models;
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
    internal class GetBookIssuedListHandler : IRequestHandler<GetBookIssuedListQueries, List<IssuedBookResponseDTO>>
    {
        private readonly LibraryDbContext dbContext;

        public GetBookIssuedListHandler(LibraryDbContext unitOfWork)
        {
            this.dbContext = unitOfWork;
        }

        public Task<List<IssuedBookResponseDTO>> Handle(GetBookIssuedListQueries request, CancellationToken cancellationToken)
        {
            var data = dbContext.IssuedBooks.Select(
             x => new IssuedBookResponseDTO
             {
                 UserId = x.User.UserId,
                 BookId = x.BooK.BookId,
                 BookIssuedID = x.IssuedBookId,
                 AuthorName = x.BooK.AuthorName,
                 BookName = x.BooK.BookName,
                 FirstName = x.User.Name,
                 EmailId = x.User.Email,
                 PhoneNumber = x.User.PhoneNumber,
                 BookSubmitDate = x.LateDate,
                 BookVolume = x.BooK.BookVolume
             }).ToList();
            return Task.FromResult(data);
        }
    }
}
