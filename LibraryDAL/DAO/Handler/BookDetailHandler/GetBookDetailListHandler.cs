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
    internal class GetBookDetailListHandler:IRequestHandler<GetBookDetailListQueries,List<BookDetail>>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public GetBookDetailListHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<BookDetail>> Handle(GetBookDetailListQueries request, CancellationToken cancellationToken)
        {
            return await unitOfWork.bookDetail.GetAll();
        }
    }
}
