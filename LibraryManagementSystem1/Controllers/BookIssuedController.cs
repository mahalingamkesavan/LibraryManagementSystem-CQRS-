using LibraryBAL.Interface;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Library.Controllers
{
    public class BookIssuedController : BaseController
    {
        private readonly IUnitOfWorkBAL unitOfWork;
        public BookIssuedController(IUnitOfWorkBAL bookIssued)
        {
            this.unitOfWork = bookIssued;
        }
        [HttpPost]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> CreateBookIssued([FromBody] IssuedBookDTO issuedBook)
        {
            var result =await unitOfWork.bookIssued.AddIssuedBookDetail(issuedBook);
            return Ok(result);
        }
        [HttpDelete("ReturnBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBookIssued(int issuedBookID)
        {
            var result =await unitOfWork.bookIssued.ReturnIssuedBookDetail(issuedBookID);
            return Ok(result);
        }
        [HttpGet("GetBookIssuedDetail")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetBookIssued(int issuedBookID)
        {
            var result =await unitOfWork.bookIssued.GetIssuedBookDetail(issuedBookID);
            return Ok(result);
        }
        [HttpGet("userReturn")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetBookIssuedByUserId()
        {
            var UserId=User.Claims.First(x=>x.Type==ClaimTypes.NameIdentifier).Value;
            var result = await unitOfWork.bookIssued.GetBookIssuedByUserId(Convert.ToInt32(UserId));
            return Ok(result);
        }
        [HttpGet("ListOfBookIssuedDetail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListOfBookIssued()
        {
            var result =await unitOfWork.bookIssued.GetALLIssuedBook();
            return Ok(result);
        }
        [HttpGet("todayReturnBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTodayBookReturnList()
        {
            var todaysReturnBook = await unitOfWork.bookIssued.GetTodaysReturnBookList();
            return Ok(todaysReturnBook);
        }
        [HttpGet("returnTimeDuration")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetReturnTimeDuration()
        {
           int UserId=Convert.ToInt32(User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var result = await unitOfWork.bookIssued.GetReturnDuration(UserId);
            return Ok(result);
        }
        
    }
}
