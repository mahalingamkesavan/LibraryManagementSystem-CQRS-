using LibraryDAL.DAO.IRepository;

using LibraryDAL.Context;
using LibraryUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Repository
{
    public class UnitOfWorkDAO : IUnitOfWorkDAL, IDisposable
    {
        internal readonly LibraryDbContext dbContext;
        public UnitOfWorkDAO(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IBookDetailRepository bookDetail => new BookDetailRepository(dbContext);

        public IUserDetailRepository userDetail =>  new UserDetailRepository(dbContext);

        public IAddressRepository address =>  new AddressRepository(dbContext);

       public IBookIssuedRepository bookIssued =>  new BookIssuedRepository(dbContext);

        public IBookTypeRepository bookType =>  new BookTypeRepository(dbContext);

        public async void Dispose()
        {
            await dbContext.DisposeAsync();
        }
        public async Task<bool> CompleteAsync()
        {
           return await dbContext.SaveChangesAsync()>0;
        }
    }
}
