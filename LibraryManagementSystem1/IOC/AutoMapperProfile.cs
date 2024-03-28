using AutoMapper;
using LibraryUtil.Models;
using LibraryUtil.DTO.RequestDTO;
using LibraryUtil.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL.IOC
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserRegistrationRequestDTO, UserRegistration>().ReverseMap();
            CreateMap<UserRegistrationRequestDTO, AddressDetail>();
            CreateMap<UserUpdateRequestDTO, UserRegistration>().ReverseMap();
            CreateMap<UserUpdateRequestDTO, AddressDetail>();
            CreateMap<IEnumerable<UserRegistration>, List<UserRegistration>>();
            CreateMap<IssuedBookDTO, IssuedBook>();
            CreateMap<UserRegistration, IssuedBookResponseDTO>();
            CreateMap< BookDetailRequestDTO,BookDetail>();
            CreateMap<BookDetailRequestDTO, BookDetail>();
            CreateMap<UpdateBookDetailRequestDTO, BookDetail>();
        }
    }
}
