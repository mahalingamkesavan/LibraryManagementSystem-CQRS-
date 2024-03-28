using LibraryDAL.Context;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using LibraryUtil.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    public class GetApprovedMessageHandler : IRequestHandler<GetApprovedMessageQueries, UserRegistration>
    {
        private readonly LibraryDbContext dbContext;
        public GetApprovedMessageHandler(LibraryDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<UserRegistration> Handle(GetApprovedMessageQueries request, CancellationToken cancellationToken)
        {
            var userData = await dbContext.UserRegistrations.Where(x => x.UserId==request.userId && x.UserStatus == "Active" && x.Notify == false).FirstOrDefaultAsync();
            return userData;
        }
    }
}
