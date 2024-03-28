﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Command.BookDetailCommand
{
    public record DeleteBookDetailCommand(int BookId):IRequest<bool>;

}
