using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class LoginDetailHandler : IRequestHandler<LoginDetailQueries, UserRegistration>
    {
        private readonly IUnitOfWorkDAL unitOfWorkDAO;

        public LoginDetailHandler(IUnitOfWorkDAL unitOfWorkDAO)
        {
            this.unitOfWorkDAO = unitOfWorkDAO;
        }
        public  Task<UserRegistration> Handle(LoginDetailQueries request, CancellationToken cancellationToken)
        {
            return Task.FromResult(unitOfWorkDAO.userDetail.Authenticate(request.LoginDetail));
        }
    }
}
