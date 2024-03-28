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
    internal class CreateAddressHandler : IRequestHandler<CreateAddressCommand, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public CreateAddressHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var IsCreate=await unitOfWork.address.Create(request.Address);
            await unitOfWork.CompleteAsync();
            return IsCreate;

        }
    }
}
