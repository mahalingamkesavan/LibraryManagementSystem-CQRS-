﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.CostemException
{
    internal class AppException:Exception
    {
        public AppException(string message) :base (message) { }

    }
}
