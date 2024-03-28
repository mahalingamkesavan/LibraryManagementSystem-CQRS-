using LibraryUtil.DTO.ResponseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Queries.BookIssuedQueries
{
    public record GetTodayReturnBookQueries():IRequest<TodaysReturnBookListDTO>;
    
}
