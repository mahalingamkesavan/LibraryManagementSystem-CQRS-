using AutoMapper;
using LibraryBAL.Interface;
using LibraryDAL.DAO.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBAL.BAO
{
    public class UnitOfWorkBAL : IUnitOfWorkBAL
    {
        IMapper mapper;
        IMediator mediator;
        public UnitOfWorkBAL(IMapper mapper,IMediator mediator)
        {
            
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public IUserDetailBAO userDetail =>  new UserDetailBAO(mapper, mediator);

        public IBookIssuedBAL bookIssued =>  new BookIssuedBAL(mapper, mediator);

        public IBookDetailBAO bookDetail =>  new BookDetailBAO(mapper,mediator);
        public IUserApprovalBAO userApproval => new UserApprovalBAO(mediator);
    }
}
