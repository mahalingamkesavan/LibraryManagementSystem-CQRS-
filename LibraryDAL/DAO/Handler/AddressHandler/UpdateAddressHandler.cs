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
    internal class UpdateAddressHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public UpdateAddressHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
           var IsUpdated= unitOfWork.address.Update(request.updatedAddress);
            unitOfWork.CompleteAsync();
            return IsUpdated;
        }
    }
}
