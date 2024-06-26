﻿using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Command.BookIssuedCommand
{
    public record CreateIssuedBookCommand(IssuedBook IssuedBook):IRequest<bool>;
   
}
