using LibraryDAL.DAO.IRepository;
using LibraryDAL.Context;
using LibraryUtil.DTO.RequestDTO;
using Microsoft.EntityFrameworkCore;
using LibraryUtil.Models;

namespace LibraryDAL.DAO.Repository
{
    public class UserDetailRepository:GenericRepository<UserRegistration> , IUserDetailRepository
    {
        public UserDetailRepository(LibraryDbContext dbContext):base(dbContext) { }

        public  UserRegistration Authenticate(UserLoginRequestDTO userLogin)
        {
            var userData =dbSet.Where(x=>x.Email==userLogin.Email && x.Password ==userLogin.Password).FirstOrDefault();
            var loginData = DataValidation(userData,"Enter valid emailID and Password" );
            return  loginData;
        }
        public  async Task<int> FindMaxUserID()
        {
          return await dbSet.MaxAsync(x=>x.UserId);
        }
        public async Task<bool> ContainEmailId(string emailId)
        {
            return await dbSet.AnyAsync(x => x.Email == emailId);
        }
        public async Task<bool> ContainPhoneNumber(string phoneNumber)
        {
            return await dbSet.AnyAsync(x=>x.PhoneNumber == phoneNumber);
        }

        public override Task<bool> Create(UserRegistration entity)
        {
            entity.CreatedDate=DateTime.Now;
            entity.CreatedBy = entity.Name;
            return base.Create(entity);
        }
      
        public override async Task<bool> Update(UserRegistration entity)
        {
            var UpdateUserRegistration = await dbSet.FindAsync(entity.UserId);
            var UpdateUser = DataValidation(UpdateUserRegistration,"Enter the Valid User Id ");
            var updatedData = UserdetailMapping(UpdateUser, entity);
            return await base.Update(updatedData);
        }
       
        private UserRegistration UserdetailMapping(UserRegistration user, UserRegistration updatedData)
        {
            user.UpdatedDate = DateTime.Now;
            user.Name = updatedData.Name;
            user.PhoneNumber = updatedData.PhoneNumber;
            user.Email = updatedData.Email;
            user.UpdatedBy = updatedData.Name;
            return user;
        }


    }
}
