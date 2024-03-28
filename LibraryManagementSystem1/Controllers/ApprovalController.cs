using LibraryBAL.Interface;
using LibraryUtil.DTO.RequestDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class ApprovalController : BaseController
    {
        private IUnitOfWorkBAL unitOfWork;
        public ApprovalController(IUnitOfWorkBAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("userApproval")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UserApprovalList()
        {
            var result =await unitOfWork.userApproval.ProcessingUserApproval();
            return Ok(result);
        }
        [HttpDelete("userRejected")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UserRejected([FromQuery] UserApprovelRequestDTO userReject)
        {
            var result = await unitOfWork.userApproval.RejectUser(userReject);
            return Ok(result);
        }
        [HttpGet("userApproved")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UserApproved([FromQuery] UserApprovelRequestDTO userApprovel)
        {
            var result =await unitOfWork.userApproval.ApprovedUser(userApprovel);
            return Ok(result);
        }
    }
}
