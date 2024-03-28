using LibraryDAL.Context;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.BookTypeQueries;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookTypeHandler
{
    internal class GetBookTypeListHandler : IRequestHandler<GetBookTypeListQueries, List<BookType>>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public GetBookTypeListHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<BookType>> Handle(GetBookTypeListQueries request, CancellationToken cancellationToken)
        {
           var BookTypeList=await unitOfWork.bookType.GetAll();
            return BookTypeList;
        }
    }
}
