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
    internal class UpdateBookIssuedHandler : IRequestHandler<UpdateIssuedBookCommand,bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public UpdateBookIssuedHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateIssuedBookCommand request, CancellationToken cancellationToken)
        {
            var IsUpdated= await unitOfWork.bookIssued.Update(request.UpdatedIssuedBook);
            await unitOfWork.CompleteAsync();
            return IsUpdated;
        }
    }
}
