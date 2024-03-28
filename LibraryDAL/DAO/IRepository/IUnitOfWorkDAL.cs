
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.DAO.IRepository
{
    public interface IUnitOfWorkDAL
    {
        IUserDetailRepository userDetail { get; }
        IAddressRepository address { get; }
        IBookIssuedRepository bookIssued { get; }
        IBookDetailRepository bookDetail { get; }
        IBookTypeRepository bookType { get; }
        Task<bool> CompleteAsync();
    }
}
