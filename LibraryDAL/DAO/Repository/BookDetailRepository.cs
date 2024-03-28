using LibraryDAL.CostemException;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LibraryUtil.Models;

namespace LibraryDAL.DAO.Repository
{
    public class BookDetailRepository:GenericRepository<BookDetail>, IBookDetailRepository
    {
        public BookDetailRepository(LibraryDbContext libraryDb):base(libraryDb) { }

        public override async Task<bool> Delete(int bookID)
        {
            var IssuedBook = dbContext.IssuedBooks.Where(x=>x.BooK.BookId== bookID).FirstOrDefault();
            if (IssuedBook != null)
                dbContext.IssuedBooks.Remove(IssuedBook);
            return await base.Delete(bookID);
           
        }
        public override async Task<bool> Update(BookDetail updatedBook)
        {
            if (updatedBook.BookId < 0)
                throw new AppException("Enter the Book Number");
            var book = dbContext.BookDetails.Find(updatedBook.BookId);
            var bookInfomation = DataValidation(book,"Book Id Is Not Found Enter the Valid Book ID Number");// this method will be check the data is there 
            BookDetail bookDetail= MapBookDetail(bookInfomation, updatedBook);// In this method will be map the table object
            return await base.Update(bookDetail);
             
        }
        private BookDetail MapBookDetail(BookDetail bookInfomation, BookDetail updatedBook)
        {
            bookInfomation.UpdatedDate = DateTime.Now;
            bookInfomation.AuthorName = updatedBook.AuthorName;
            bookInfomation.BookVolume = updatedBook.BookVolume;
            bookInfomation.BookName = updatedBook.BookName;
            bookInfomation.TypeOfBook = updatedBook.TypeOfBook;
            return bookInfomation;
        }

    }
}
