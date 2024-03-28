using LibraryDAL.DAO.Command.UserDetailCommand;
using LibraryDAL.DAO.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserDetailCommand, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public UpdateUserHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateUserDetailCommand request, CancellationToken cancellationToken)
        {
            bool IsUpdated = await unitOfWork.userDetail.Update(request.updateUser);
            await unitOfWork.CompleteAsync();
            return IsUpdated;
        }
    }
}
