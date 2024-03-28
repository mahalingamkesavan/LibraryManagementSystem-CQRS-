

using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;

namespace LibraryBAL.Interface
{
    public interface IUserDetailBAO
    {
        public Task<ResultResponseDTO> CreateUserDetail(UserRegistrationRequestDTO userDetail);
        public Task<ResultResponseDTO> UpdateUserDetail(UserUpdateRequestDTO userDetail);
        public Task<ResultResponseDTO> DeleteUserDetail(int UserID);
        public Task<UserUpdateRequestDTO> GetUserDetail(int UserID);

        public Task<UserRegistration> UserLogin(UserLoginRequestDTO userLogin);
        public Task<AllUserDetailResponseDTO> AllUserDetail();
        public Task<UserRegistration> GetApproveMessage(int UserId);
        public Task<ResultResponseDTO> RemoveUserMessage(int UserID);
    }
}
