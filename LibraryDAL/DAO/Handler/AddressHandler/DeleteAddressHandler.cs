using LibraryDAL.DAO.Command.AddressCommand;
using LibraryDAL.DAO.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.AddressHandler
{
    internal class DeleteAddressHandler : IRequestHandler<DeleteAddressCommand, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public DeleteAddressHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
           var IsDeleted=await unitOfWork.address.Delete(request.AddressId);
           await unitOfWork.CompleteAsync();
           return IsDeleted;

        }
    }
}
