using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryUtil.Models;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class GetUserDetailHandler : IRequestHandler<GetUserDetailByIdQueries, UserRegistration>
    {
        private readonly IUnitOfWorkDAL unitOfWorkDAL;
        public GetUserDetailHandler(IUnitOfWorkDAL unitOfWorkDAL)
        {
            this.unitOfWorkDAL = unitOfWorkDAL;
        }

        public async Task<UserRegistration> Handle(GetUserDetailByIdQueries request, CancellationToken cancellationToken)
        {
            return await unitOfWorkDAL.userDetail.GetById(request.ID);
        }
    }
}
