using LibraryDAL.Context;
using LibraryDAL.DAO.Command.UserDetailCommand;
using LibraryDAL.DAO.IRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    internal class DeleteUserHandler : IRequestHandler<DeleteUserDetailCommand, bool>
    {

        private readonly LibraryDbContext dbContext;

        public DeleteUserHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteUserDetailCommand request, CancellationToken cancellationToken)
        {
            var user = dbContext.UserRegistrations.Where(x => x.UserId == request.Id).FirstOrDefault();
            if (user == null)
                throw new ApplicationException("User is Not Found");
            var IsDeleted = await dbContext.IssuedBooks.Where(x => x.UserId == request.Id).ToListAsync();
            if (IsDeleted.Count > 0)
                dbContext.IssuedBooks.RemoveRange(IsDeleted);
            dbContext.UserRegistrations.Remove(user);
            dbContext.SaveChanges();
            return true;
        }
    }
}
