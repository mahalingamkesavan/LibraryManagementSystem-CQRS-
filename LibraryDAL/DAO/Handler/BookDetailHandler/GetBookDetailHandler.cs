using LibraryDAL.DAO.Command.BookDetailCommand;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.BookDetailQueries;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookDetailHandler
{
    internal class GetBookDetailHandler : IRequestHandler<GetBookDetailByIdQueries, BookDetail>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public GetBookDetailHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<BookDetail> Handle(GetBookDetailByIdQueries request, CancellationToken cancellationToken)
        {
            return unitOfWork.bookDetail.GetById(request.BookId);
        }
    }
}
