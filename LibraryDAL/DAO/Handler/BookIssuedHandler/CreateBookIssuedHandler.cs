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
    internal class CreateBookIssuedHandler:IRequestHandler<CreateIssuedBookCommand,bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public CreateBookIssuedHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateIssuedBookCommand request, CancellationToken cancellationToken)
        {
            var IsCreated= await unitOfWork.bookIssued.Create(request.IssuedBook);
            await unitOfWork.CompleteAsync();
            return IsCreated;
        }
    }
}
