using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using LibraryDAL.DAO.Repository;
using LibraryDAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryUtil.Models;

namespace LibraryDAL.DAO.Handler.UserDetailHandler
{
    public class GetUserDetailListHandler : IRequestHandler<GetListUserDetailQueries, List<UserRegistration>>
    {
        private readonly LibraryDbContext dbContext;

        public GetUserDetailListHandler(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserRegistration>> Handle(GetListUserDetailQueries request, CancellationToken cancellationToken)
        {
            return await dbContext.UserRegistrations.Where(x => x.Role == "User" && x.ApprovedBy != null).ToListAsync();
        }
    }
}
