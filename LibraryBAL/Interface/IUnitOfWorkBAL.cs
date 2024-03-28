using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL.Interface
{
    public interface IUnitOfWorkBAL
    {
        IUserDetailBAO userDetail { get; }
        IBookIssuedBAL bookIssued { get; }
        IBookDetailBAO bookDetail { get; }
        IUserApprovalBAO userApproval { get; }

    }
}
