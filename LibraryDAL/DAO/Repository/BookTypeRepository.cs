using LibraryDAL.Context;
using LibraryDAL.DAO.IRepository;
using LibraryUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Repository
{
    public class BookTypeRepository:GenericRepository<BookType>,IBookTypeRepository
    {
        public BookTypeRepository(LibraryDbContext dbContext) : base(dbContext) { }
    }
}
