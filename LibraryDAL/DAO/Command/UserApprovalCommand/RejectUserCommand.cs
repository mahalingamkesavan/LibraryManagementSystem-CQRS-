using LibraryUtil.DTO.RequestDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Command.UserApprovalCommand
{
    public record RejectUserCommand(UserApprovelRequestDTO userReject):IRequest<bool>;
    
}
