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
    internal class CreateBookDetailHandler : IRequestHandler<CreateBookDetailCommend, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public CreateBookDetailHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateBookDetailCommend request, CancellationToken cancellationToken)
        {
            var IsCreate= await unitOfWork.bookDetail.Create(request.BookDetail);
            await unitOfWork.CompleteAsync();
            return IsCreate;
        }
    }
}
