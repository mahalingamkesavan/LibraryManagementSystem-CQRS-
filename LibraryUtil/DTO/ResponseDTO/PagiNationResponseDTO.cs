using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtil.DTO.ResponseDTO
{
    public class PagiNationResponseDTO<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int TotalNoOfRecords { get; set; }
        public int PageSize  { get; set; }
        public List<T>? Items { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;

        public PagiNationResponseDTO(int CurrentPage,int TotalPage,int TotalNoOfRecords,int PageSize,List<T> Items) 
        {
            this.CurrentPage = CurrentPage; 
            this.TotalPage = TotalPage;
            this.TotalNoOfRecords = TotalNoOfRecords;
            this.PageSize = PageSize;
            this.Items = Items;
        }
    }
}
