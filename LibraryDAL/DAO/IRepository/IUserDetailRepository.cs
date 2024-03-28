
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.IRepository
{
    public interface IUserDetailRepository:IGenericRepository<UserRegistration>
    {
       public UserRegistration Authenticate(UserLoginRequestDTO userLogin);
        public  Task<int> FindMaxUserID();
        public  Task<bool> ContainEmailId(string emailId);
        public Task<bool> ContainPhoneNumber(string phoneNumber);

    }
}
