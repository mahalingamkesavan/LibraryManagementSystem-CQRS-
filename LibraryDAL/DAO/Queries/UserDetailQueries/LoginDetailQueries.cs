using LibraryUtil.Models;
using LibraryUtil.DTO.RequestDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Queries.UserDetailQueries
{
    public record LoginDetailQueries(UserLoginRequestDTO LoginDetail) :IRequest<UserRegistration>;
   
}
