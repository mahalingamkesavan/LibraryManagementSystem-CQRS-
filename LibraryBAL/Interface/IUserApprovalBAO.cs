using LibraryUtil.Models;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryUtil.DTO.RequestDTO;

namespace LibraryBAL.Interface
{
    public interface IUserApprovalBAO
    {
        public Task<AllUserDetailResponseDTO> ProcessingUserApproval();
        public Task<ResultResponseDTO> RejectUser(UserApprovelRequestDTO userId);
        public Task<ResultResponseDTO> ApprovedUser(UserApprovelRequestDTO userId);
    } 
}
