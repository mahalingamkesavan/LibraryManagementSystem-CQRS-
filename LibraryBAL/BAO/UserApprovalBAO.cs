using LibraryBAL.Interface;
using LibraryDAL.DAO.Command.UserApprovalCommand;
using LibraryUtil.Models;
using LibraryUtil.DTO.ResponseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryUtil.DTO.RequestDTO;

namespace LibraryBAL.BAO
{
    internal class UserApprovalBAO : IUserApprovalBAO
    {
        private IMediator mediator;

        public UserApprovalBAO(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<ResultResponseDTO> ApprovedUser(UserApprovelRequestDTO userApprovel)
        {
            var IsApproved =await mediator.Send(new ApprovedUserCommand(userApprovel));
            return ResponseMessageDetail.resultResponse(IsApproved, Constants.UserApprovel.Approved);
        }

        public async Task<AllUserDetailResponseDTO> ProcessingUserApproval()
        {
            AllUserDetailResponseDTO UserApproval = new AllUserDetailResponseDTO();
             UserApproval.AllUser= await mediator.Send(new ProcessingUserApprovalCommand());
                return UserApproval;
        }

        public async Task<ResultResponseDTO> RejectUser(UserApprovelRequestDTO userReject)
        {
            var IsApproved = await mediator.Send(new RejectUserCommand(userReject));
           return ResponseMessageDetail.resultResponse(IsApproved, Constants.UserApprovel.Rejected);
        }
    }
}
