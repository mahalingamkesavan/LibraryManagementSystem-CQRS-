using AutoMapper;
using LibraryBAL.Interface;
using LibraryDAL.DAO.Command.BookIssuedCommand;
using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.BookDetailQueries;
using LibraryDAL.DAO.Queries.BookIssuedQueries;
using LibraryDAL.DAO.Queries.UserDetailQueries;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL.BAO
{
    public class BookIssuedBAL : IBookIssuedBAL
    {
        
        private IMapper mapper;
        private IMediator mediator;
        public BookIssuedBAL(IMapper mapper,IMediator mediator)
        {
            
            this.mapper = mapper;
            this.mediator=mediator;
        }
        public async Task<ResultResponseDTO> AddIssuedBookDetail(IssuedBookDTO issuedBook)
        {
            IssuedBook issuedBookDetail = mapper.Map<IssuedBook>(issuedBook);
            issuedBookDetail.CreatedBy = issuedBook.Name;
            bool IsExcute=await mediator.Send(new CreateIssuedBookCommand(issuedBookDetail));
            return ResponseMessageDetail.resultResponse(IsExcute,Constants.BookIssued.Issued);
        }

        public async Task<IssuedBookListResponseDTO> GetALLIssuedBook()
        {
            IssuedBookListResponseDTO issuedBookList = new IssuedBookListResponseDTO();
            issuedBookList.listOfIssuedBook = await mediator.Send(new GetBookIssuedListQueries());
            return issuedBookList;
        }

        public async Task<IssuedBookListResponseDTO> GetBookIssuedByUserId(int UserId)
        {
            IssuedBookListResponseDTO issuedBookList = new IssuedBookListResponseDTO();
            issuedBookList.listOfIssuedBook = await mediator.Send(new GetBookIssuedByUserIdQueries(UserId));
            return issuedBookList;
        }

        public async Task<IssuedBookResponseDTO> GetIssuedBookDetail(int issuedBookID)
        {
            var result=await mediator.Send(new GetBookIssuedByIdQueries(issuedBookID));
            return result;
        }

        public async Task<ListReturnDurationResponseDTO> GetReturnDuration(int UserId)
        {
            ListReturnDurationResponseDTO returnDuration = new ListReturnDurationResponseDTO();
            returnDuration.ReturnDuration = await mediator.Send(new GetReturnDurationIssuedBookQueries(UserId));
            foreach (var item in returnDuration.ReturnDuration)
            {
                var date = item.PurchaseDate;
                string purchaseDate=date.ToShortDateString();
                string[] purchaseDay = purchaseDate.Split("-");
                int purchasedDayValue=Convert.ToInt32(purchaseDay[0]);
                int purchasedMonthValue = Convert.ToInt32(purchaseDay[1]);
                int currentDay = DateTime.Now.Day;
               int currentMonth = DateTime.Now.Month;
                if (purchasedDayValue < currentDay)
                {
                    int holdingDay = currentDay - purchasedDayValue;
                    item.HoldingDays =holdingDay;
                    item.RemainingDays =30 - holdingDay;
                } 
                else if (purchasedDayValue == currentDay)
                {
                    if (purchasedMonthValue == currentMonth)
                    {
                        item.HoldingDays = 30;
                        item.RemainingDays = 0;
                    }
                    item.HoldingDays = 0;
                    item.RemainingDays = 30;
                } 
                else
                {
                    int holdingDay = purchasedDayValue - currentDay;
                    item.HoldingDays = holdingDay;
                    item.RemainingDays = (30 - holdingDay);
                }
                    
           }
            return returnDuration;
        }

        public async Task<TodaysReturnBookListDTO> GetTodaysReturnBookList()
        {
            TodaysReturnBookListDTO todaysReturnBook = await mediator.Send(new GetTodayReturnBookQueries());
            return todaysReturnBook;
        }

        public async Task<ResultResponseDTO> ReturnIssuedBookDetail(int issuedBookID)
        {
            bool IsExcute =await mediator.Send(new DeleteIssuedBookCommand(issuedBookID));
            return ResponseMessageDetail.resultResponse(IsExcute,Constants.BookIssued.ReturnBook);
        }
    }
}
