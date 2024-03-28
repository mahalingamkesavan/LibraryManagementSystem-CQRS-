using LibraryDAL.Context;
using LibraryDAL.DAO.Queries.BookIssuedQueries;
using LibraryDAL.DAO.Repository;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookDetailHandler
{
    internal class GetBookPagiNationHandler : IRequestHandler<GetBookPagiNationQueries, PagiNationResponseDTO<BookDetail>>
    {
        private LibraryDbContext dbContext;
        public GetBookPagiNationHandler(LibraryDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<PagiNationResponseDTO<BookDetail>> Handle(GetBookPagiNationQueries request, CancellationToken cancellationToken)
        {
            var totalNumberOfBook = dbContext.BookDetails.Count();
            var totalPage = (int)Math.Ceiling(totalNumberOfBook / (double)request.pagiNation.PageSize);
           var bookList=await dbContext.BookDetails
                .Skip((request.pagiNation.PageNumber-1)*request.pagiNation.PageSize)
                .Take(request.pagiNation.PageSize).ToListAsync();
            PagiNationResponseDTO<BookDetail> BookList = new PagiNationResponseDTO<BookDetail>
                (request.pagiNation.PageNumber, totalPage, totalNumberOfBook, request.pagiNation.PageSize, bookList);
            return BookList;
            
        }
    }
}
