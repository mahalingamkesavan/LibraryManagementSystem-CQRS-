using LibraryDAL.Context;
using LibraryDAL.CostemException;
using LibraryDAL.DAO.Command.UserApprovalCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserApprovalHandler
{
    public class ApprovedUserHandler : IRequestHandler<ApprovedUserCommand, bool>
    {
        private LibraryDbContext dbContext;
        public ApprovedUserHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Handle(ApprovedUserCommand request, CancellationToken cancellationToken)
        {
            var UserDetail = await dbContext.UserRegistrations.FindAsync(request.userApprovel.UserId);
            if (UserDetail == null) { throw new AppException("User Id is not Found"); }
            UserDetail.UserStatus = "Active";
            UserDetail.ApprovedBy = request.userApprovel.ApprovedBy;
            dbContext.UserRegistrations.Update(UserDetail);
            dbContext.SaveChanges();
            return true;
        }
    }
}
