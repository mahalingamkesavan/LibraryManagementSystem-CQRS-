using AutoMapper;
using LibraryBAL.Interface;
using LibraryBAL.Validation;
using LibraryDAL.DAO.Command.AddressCommand;
using LibraryDAL.DAO.Command.UserDetailCommand;
using LibraryDAL.DAO.Queries.AddressQueries;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using MediatR;

namespace LibraryBAL.BAO
{
    public class UserDetailBAO : IUserDetailBAO
    {
        
        private IMapper mapper;
        private IMediator mediator;
        public UserDetailBAO(IMapper mapper,IMediator mediator)
        {
           
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<AllUserDetailResponseDTO> AllUserDetail()
        {
            AllUserDetailResponseDTO allUserDetail =new AllUserDetailResponseDTO();
            allUserDetail.AllUser = await mediator.Send(new GetListUserDetailQueries());
            return allUserDetail;
        }
        public  async Task<UserRegistration> UserLogin(UserLoginRequestDTO userLogin)
        {
            return await mediator.Send(new LoginDetailQueries(userLogin));
        }

        public async Task<ResultResponseDTO> CreateUserDetail(UserRegistrationRequestDTO userDetail)
        {
          
            var userInformation = mapper.Map<UserRegistration>(userDetail);
            if (userInformation.Role == Constants.Messages.Admin)
            {
                userInformation.UserStatus = Constants.Messages.Active;
                userDetail.Address = Constants.Messages.Address;
                userDetail.City = Constants.Messages.City; 
                userDetail.State = Constants.Messages.State;
            }
            else
            {
                userInformation.Role = Constants.Messages.User;
                userInformation.UserStatus = Constants.Messages.Processing;
            }
                
            await UserDetailValid(userInformation);
            var addressInformation=mapper.Map<AddressDetail>(userDetail);
            addressInformation.UserId = await mediator.Send(new CreateUserDetailCommand(userInformation));
            bool IsExcute = await mediator.Send(new CreateAddressCommand(addressInformation));
            return ResponseMessageDetail.resultResponse(IsExcute, $"Your User ID is :{addressInformation.UserId}");
        }

        public async Task<ResultResponseDTO> DeleteUserDetail(int UserID)
        {
            await mediator.Send(new DeleteAddressCommand(UserID));
            bool IsExcute = await mediator.Send(new DeleteUserDetailCommand(UserID));
            return ResponseMessageDetail.resultResponse(IsExcute, Constants.UserRegistration.UserDeleted);
        }

        public async Task<UserUpdateRequestDTO> GetUserDetail(int UserID)
        {
           
            var user= await mediator.Send(new GetUserDetailByIdQueries(UserID));
            var userInformation= mapper.Map<UserUpdateRequestDTO>(user);
            var addressdetail= await mediator.Send(new GetAddressQueries(UserID));
            userInformation.City = addressdetail.City;
            userInformation.Address = addressdetail.Address;
            userInformation.Address= addressdetail.Address;
            return userInformation;
          
        }
        public async Task<UserRegistration> GetApproveMessage(int UserId)
        {
            var UserData = await mediator.Send(new GetApprovedMessageQueries(UserId));
            return UserData;
        }
        public async Task<ResultResponseDTO> RemoveUserMessage(int UserID)
        {
            var IsExcute = await mediator.Send(new UpdateNotifyMessageCommand(UserID));
            return ResponseMessageDetail.resultResponse(IsExcute, Constants.UserRegistration.RemoveUserMessage);
        }

        public async Task<ResultResponseDTO> UpdateUserDetail(UserUpdateRequestDTO userDetail)
        {
            var updatedData = mapper.Map<UserRegistration>(userDetail);
            //await UserDetailValid(updatedData);
            bool IsExcute = await mediator.Send(new UpdateUserDetailCommand(updatedData));
            var updatedAddress=mapper.Map<AddressDetail>(userDetail);
            await mediator.Send(new UpdateAddressCommand(updatedAddress));
            return ResponseMessageDetail.resultResponse(IsExcute,Constants.UserRegistration.UpdateUser);
        }
        
        private async Task IsValidEmail(string email)
        {
            var data=UserDetailValidation.IsValidEmailFormat(email);
            if (!data)
                throw new ApplicationException("Enter the valid Email ID");
            bool isValid = await mediator.Send(new Emailvalidation(email));
            if (isValid)
                throw new ApplicationException("The Email Id Is Allready exist ");
        }
        private async Task IsValidPhoneNumber(string phoneNumber)
        {
            var data =UserDetailValidation.IsPhoneNumberFormat(phoneNumber);
            if (!data)
                throw new ApplicationException("Enter the valid Phone Number ID");
            bool isContain=await mediator.Send(new PhoneNumberValidationQueries(phoneNumber));
            if (isContain)
                throw new ApplicationException("The Phone Number Is Allready exist ");
        }
        private async Task UserDetailValid(UserRegistration userInformation)
        {
            await IsValidEmail(userInformation.Email);
            await IsValidPhoneNumber(userInformation.PhoneNumber);
        }

        
    }
}
