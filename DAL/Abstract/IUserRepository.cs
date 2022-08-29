using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IUserRepository:IEFBaseRepository<User>
    {
        User GetUserWithPassword(string email);

    }
}
