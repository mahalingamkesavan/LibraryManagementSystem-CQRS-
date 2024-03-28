﻿
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Queries.UserDetailQueries
{
    public record GetUserDetailByIdQueries(int ID):IRequest<UserRegistration>;   
}