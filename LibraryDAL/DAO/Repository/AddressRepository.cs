using LibraryDAL.DAO.IRepository;
using LibraryDAL.Context;
using LibraryUtil.Models;
using LibraryBAL;
#nullable disable

namespace LibraryDAL.DAO.Repository
{
    public class AddressRepository:GenericRepository<AddressDetail>,IAddressRepository
    {
        public AddressRepository( LibraryDbContext dbContext):base(dbContext) { }

        public override async Task<bool> Create(AddressDetail entity)
        {

            entity.CreatedDate=DateTime.Now;
            entity.CreatedBy = Constants.Messages.User;
           return await base.Create(entity);
        }
        public override async Task<bool> Update(AddressDetail address)
        {
            AddressDetail addressDetail = FindAddressDetail(Convert.ToInt32(address.UserId));
             var UpdatedAddress = MapAddressDetail(addressDetail, address);
            return await base.Update(UpdatedAddress);
        }
        public override async Task<bool> Delete(int UserID)
        {
            AddressDetail addressDetail = FindAddressDetail(UserID);
            return await base.Delete(addressDetail.AddressId);
        }
        public override async Task<AddressDetail> GetById(int id)
        {
            AddressDetail addressDetail = FindAddressDetail(id);
            return await base.GetById(addressDetail.AddressId);
        }
        private AddressDetail FindAddressDetail(int UserID)
        {
            AddressDetail addressDetail = dbSet.Where(x => x.UserId == UserID).FirstOrDefault();
            var data = DataValidation(addressDetail,"Address Detail is Not Found");
            return data;
        }

        private AddressDetail MapAddressDetail(AddressDetail address, AddressDetail updatedData)
        {
            address.City = updatedData.City;
            address.Address = updatedData.Address;
            address.UpdatedDate = DateTime.Now;
            address.UpdatedBy = Constants.Messages.User;
            return address;
        }
    }
}
