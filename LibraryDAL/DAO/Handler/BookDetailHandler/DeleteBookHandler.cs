using LibraryDAL.DAO.Command.BookDetailCommand;
using LibraryDAL.DAO.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookDetailHandler
{
    internal class DeleteBookHandler:IRequestHandler<DeleteBookDetailCommand,bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public DeleteBookHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteBookDetailCommand request, CancellationToken cancellationToken)
        {
            var IsDelete=await unitOfWork.bookDetail.Delete(request.BookId);
            await unitOfWork.CompleteAsync();
            return IsDelete;
        }
    }
}
