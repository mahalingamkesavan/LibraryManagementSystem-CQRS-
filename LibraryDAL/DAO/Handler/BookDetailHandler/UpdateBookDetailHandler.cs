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
    internal class UpdateBookDetailHandler:IRequestHandler<UpdateBookDetailCommand,bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public UpdateBookDetailHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateBookDetailCommand request, CancellationToken cancellationToken)
        {
            var IsUpdated=await unitOfWork.bookDetail.Update(request.updatedBookDetail);
            await unitOfWork.CompleteAsync();
            return IsUpdated;
        }
    }
}
