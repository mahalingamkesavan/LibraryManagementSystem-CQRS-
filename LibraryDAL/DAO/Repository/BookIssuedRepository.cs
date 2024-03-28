using LibraryDAL.CostemException;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.Context;
using LibraryUtil.Models;
using LibraryUtil.DTO.ResponseDTO;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Ocsp;

namespace LibraryDAL.DAO.Repository
{
    public class BookIssuedRepository:GenericRepository<IssuedBook>, IBookIssuedRepository
    {
        public BookIssuedRepository(LibraryDbContext dbContext):base(dbContext) { }

        public override async Task<bool> Create(IssuedBook entity)
        {
            IssuedBook issued = new IssuedBook();
            var UserID = dbContext.UserRegistrations.Where(x => x.UserId == entity.UserId).FirstOrDefault();
            var bookID = dbContext.BookDetails.Where(x => x.BookId == entity.BooKid).FirstOrDefault();

            if (UserID == null)
                throw new AppException("User Id is not Found Please enter the valid User ID");

            if (bookID == null)
                throw new AppException("Book Id is not Correct Please Enter the valid Book Id");
            
            if(UserID.UserStatus=="Active")
            {
               var bookIsExist= dbContext.IssuedBooks.Where(x => x.BooKid == entity.BooKid && x.UserId == entity.UserId).FirstOrDefault();
                if (bookIsExist != null)
                    throw new AppException("This Book is Allready Issued");
                entity.CreatedDate = DateTime.Now;
                var CreatedDate = DateTime.Now;
                entity.LateDate = new DateTime(CreatedDate.Year, CreatedDate.Month + 1, CreatedDate.Day);
                return await base.Create(entity);
            }
            else { throw new AppException("User Is Not Approved by Admin"); }
            
        }
       


    }
}
