using LibraryDAL.DAO.IRepository;
using LibraryDAL.DAO.Queries.AddressQueries;
using LibraryUtil.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.Handler.AddressHandler
{
    internal class GetAddressByIdHandler : IRequestHandler<GetAddressQueries, AddressDetail>
    {
        private readonly IUnitOfWorkDAL unitOfWork;

        public GetAddressByIdHandler(IUnitOfWorkDAL unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<AddressDetail> Handle(GetAddressQueries request, CancellationToken cancellationToken)
        {
           return unitOfWork.address.GetById(request.AddressID);
        }
    }
}
