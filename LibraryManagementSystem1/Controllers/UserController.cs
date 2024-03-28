using Library.Controllers;
using LibraryBAL.Interface;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem1.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUnitOfWorkBAL userDetail;
        private readonly IConfiguration configuration;
        public UserController(IUnitOfWorkBAL userDetail, IConfiguration configuration)
        {
            this.userDetail = userDetail;
            this.configuration = configuration;
        }
        [HttpPost("UserRegistration")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserDetail([FromBody] UserRegistrationRequestDTO user)
        {
            var result =await userDetail.userDetail.CreateUserDetail(user);
            return Ok(result);
        }
        [HttpPut("UpdateUserDetail")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUserDetail([FromBody] UserUpdateRequestDTO userUpdate)
        {
            var result =await userDetail.userDetail.UpdateUserDetail(userUpdate);
            return Ok(result);
        }
        [HttpDelete("DeleteUserDetail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserDetail(int UserID)
        {
            var result =await userDetail.userDetail.DeleteUserDetail(UserID);
            return Ok(result);
        }
        [HttpGet()]
        [Authorize(Roles ="User,Admin")]
       
        public async Task<IActionResult> GetUserDetail()
        {
            var userId = GetUserId();
            var result =await userDetail.userDetail.GetUserDetail(userId);
            return Ok(result);
        }
        [HttpGet("GetAllUserDetail")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllUserDetail()
        {
            var result =await userDetail.userDetail.AllUserDetail();
            return Ok(result);
        }
        [HttpPost("UserLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequestDTO userLogin)
        {
            JwtTokenResponse jwtTokenResponse = new JwtTokenResponse();
            UserRegistration userdetail = await userDetail.userDetail.UserLogin(userLogin);
            jwtTokenResponse.AccessToken = CreateToken(userdetail);
            return Ok(jwtTokenResponse);
        }
        [HttpGet("message")]
        [Authorize(Roles ="User,Admin")]
        public async Task<IActionResult> GetUserMessage()
        {
            var userId = GetUserId();
            var result = await userDetail.userDetail.GetApproveMessage(userId);
            if (result == null)
                return NoContent();
            return Ok(result);
        }
        [HttpGet("removeMessage")]
        [Authorize(Roles = "User,Admin")]
        public async Task <IActionResult> RemoveUserMessage()
        {
            int userID = GetUserId();
            var result =await userDetail.userDetail.RemoveUserMessage(userID);
            return Ok(result);
        }
        private int GetUserId() 
        {
            var userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            int userID = Convert.ToInt32(userId);
            return userID;
        }
        private string CreateToken(UserRegistration userdetail)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:key"]));
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,userdetail.Name),
                new Claim(ClaimTypes.Role,userdetail.Role),
                new Claim(ClaimTypes.NameIdentifier,userdetail.UserId.ToString())
            };
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = signingCredentials

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
