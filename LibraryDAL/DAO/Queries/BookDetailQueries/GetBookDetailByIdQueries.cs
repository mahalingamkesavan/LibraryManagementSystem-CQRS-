using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Queries.BookDetailQueries
{
    public record GetBookDetailByIdQueries(int BookId):IRequest<BookDetail>;
    
}
