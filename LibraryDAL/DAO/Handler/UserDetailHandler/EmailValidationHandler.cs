using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class EmailValidationHandler : IRequestHandler<Emailvalidation, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public EmailValidationHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<bool> Handle(Emailvalidation request, CancellationToken cancellationToken)
        {
           return unitOfWork.userDetail.ContainEmailId(request.EmailId);
        }
    }
}
