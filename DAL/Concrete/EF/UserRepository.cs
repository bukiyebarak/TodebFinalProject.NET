using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Linq;

namespace DAL.Concrete.EF
{
    public class UserRepository : EFBaseRepository<User, DBContext>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        } 

        //join işlemi
        public User GetUserWithPassword(string email)
        {
            return Context.Users
                .Include(x => x.Password)
                .FirstOrDefault(x => x.Email == email);
        }
    }
}
