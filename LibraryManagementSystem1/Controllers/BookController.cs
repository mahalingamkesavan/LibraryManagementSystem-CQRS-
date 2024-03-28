using Library.Controllers;
using LibraryBAL.Interface;
using LibraryUtil.Models;
using LibraryUtil.DTO.RequestDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;


namespace LibraryManagementSystem1.Controllers
{
    public class BookController : BaseController
    {
        private readonly IUnitOfWorkBAL unitOfWork;
        public BookController(IUnitOfWorkBAL bookDetail)
        {
            this.unitOfWork = bookDetail;
        }
    
        [HttpPost("AddBook")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddBook([FromBody]BookDetailRequestDTO bookDetailRequestDTO)
        {
            var result =await unitOfWork.bookDetail.AddBook(bookDetailRequestDTO);
            return Ok(result);
        }
        [HttpPut("UpdateBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDetailRequestDTO updatedBook)
        {
            var result= await unitOfWork.bookDetail.UpdateBook(updatedBook);
            return Ok(result);
        }
        [HttpDelete("DeleteBook")]
        [Authorize(Roles= "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result =await unitOfWork.bookDetail.DeleteBook(id);
            return Ok(result);
        }
        [HttpGet("GetBook")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBook(int id)
        {
            var result=await unitOfWork.bookDetail.GetBookDetail(id);
            return Ok(result);
        }
        [HttpGet("GetAllBooks")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllBook()
        {
            var result=await unitOfWork.bookDetail.GetAllBook();
            return Ok(result);
        }
        [HttpGet("typeOfBook")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllBookType()
        {
            var result =await unitOfWork.bookDetail.AllBookType();
            return Ok(result);
        }
        [HttpGet("GetAllBook")]
        [Authorize(Roles ="Admin,User")]
        public async Task<IActionResult> GetPageNationData([FromQuery]PagiNationRequestDTO pagiNation)
        {
            var bookList = await unitOfWork.bookDetail.GetAllBookPagiNation(pagiNation);
           return Ok(bookList);
        }

    }
}
