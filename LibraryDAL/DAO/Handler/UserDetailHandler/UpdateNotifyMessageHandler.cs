using LibraryDAL.Context;
using LibraryDAL.DAO.Command.UserDetailCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class UpdateNotifyMessageHandler : IRequestHandler<UpdateNotifyMessageCommand, bool>
    {
        private LibraryDbContext dbContext;
        public UpdateNotifyMessageHandler(LibraryDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateNotifyMessageCommand request, CancellationToken cancellationToken)
        {
            var userData=await dbContext.UserRegistrations.FindAsync(request.UserId);
            if (userData == null)
                return false;
            userData.Notify = true;
            dbContext.UserRegistrations.Update(userData);
            return dbContext.SaveChanges()>0;
        }
    }
}
