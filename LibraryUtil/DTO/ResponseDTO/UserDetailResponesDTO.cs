using LibraryUtil.DTO.RequestDTO;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class UserDetailResponesDTO : ResultDetailDTO
    {
        public UserRegistrationRequestDTO? User { get; set; }
    }
}
