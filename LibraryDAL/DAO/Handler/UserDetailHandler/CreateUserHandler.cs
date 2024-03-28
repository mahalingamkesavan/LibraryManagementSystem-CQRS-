using LibraryDAL.DAO.Command.UserDetailCommand;
using LibraryDAL.DAO.IRepository;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class CreateUserHandler : IRequestHandler<CreateUserDetailCommand, int>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public CreateUserHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateUserDetailCommand request, CancellationToken cancellationToken)
        {
            var IsCreated = await unitOfWork.userDetail.Create(request.User);
            await unitOfWork.CompleteAsync();
            return await unitOfWork.userDetail.FindMaxUserID();

        }
    }
}
