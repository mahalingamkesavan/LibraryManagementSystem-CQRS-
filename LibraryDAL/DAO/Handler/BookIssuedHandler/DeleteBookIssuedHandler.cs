using LibraryDAL.DAO.Command.BookDetailCommand;
using LibraryDAL.DAO.Command.BookIssuedCommand;
using LibraryDAL.DAO.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.BookIssuedHandler
{
    internal class DeleteBookIssuedHandler:IRequestHandler<DeleteIssuedBookCommand,bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public DeleteBookIssuedHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteIssuedBookCommand request, CancellationToken cancellationToken)
        {
            var IsDeleted=await unitOfWork.bookIssued.Delete(request.Id);
            await unitOfWork.CompleteAsync();
            return IsDeleted;
        }
    }
}
