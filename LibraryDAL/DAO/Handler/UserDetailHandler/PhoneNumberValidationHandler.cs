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
    internal class PhoneNumberValidationHandler : IRequestHandler<PhoneNumberValidationQueries, bool>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public PhoneNumberValidationHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(PhoneNumberValidationQueries request, CancellationToken cancellationToken)
        {
            return await unitOfWork.userDetail.ContainPhoneNumber(request.PhoneNumber);
        }
    }
}
