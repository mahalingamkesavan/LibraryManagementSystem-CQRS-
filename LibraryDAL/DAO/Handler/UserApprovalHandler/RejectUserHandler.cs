using LibraryDAL.Context;
using LibraryDAL.CostemException;
using LibraryDAL.DAO.Command.UserApprovalCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserApprovalHandler
{
    internal class RejectUserHandler : IRequestHandler<RejectUserCommand, bool>
    {
        private LibraryDbContext dbContext;
        public RejectUserHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(RejectUserCommand request, CancellationToken cancellationToken)
        {
            var UserDetail =await dbContext.UserRegistrations.FindAsync(request.userReject.UserId);
            if(UserDetail == null) { throw new AppException("User Id is not Found"); }
            UserDetail.UserStatus = "InActive";
            UserDetail.ApprovedBy=request.userReject.ApprovedBy;
            dbContext.UserRegistrations.Update(UserDetail);
            dbContext.SaveChanges();
            return true;
        }
    }
}
