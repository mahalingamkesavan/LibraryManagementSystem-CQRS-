using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Queries.BookIssuedQueries
{
    public record GetBookPagiNationQueries(PagiNationRequestDTO pagiNation) :IRequest<PagiNationResponseDTO<BookDetail>>;
    
}
