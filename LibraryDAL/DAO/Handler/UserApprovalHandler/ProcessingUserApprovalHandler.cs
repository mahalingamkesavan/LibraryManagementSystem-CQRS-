using LibraryDAL.Context;
using LibraryDAL.DAO.Command.UserApprovalCommand;
using LibraryUtil.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.UserApprovalHandler
{
    internal class ProcessingUserApprovalHandler : IRequestHandler<ProcessingUserApprovalCommand, List<UserRegistration>>
    {
        public LibraryDbContext dbContext;
        public ProcessingUserApprovalHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<UserRegistration>> Handle(ProcessingUserApprovalCommand request, CancellationToken cancellationToken)
        {
            var ProcessingUser =await dbContext.UserRegistrations.Where(x => x.UserStatus == "Processing").ToListAsync();
            return ProcessingUser;
        }
    }
}
