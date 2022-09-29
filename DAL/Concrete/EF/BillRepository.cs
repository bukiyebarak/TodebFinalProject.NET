using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class BillRepository : EFBaseRepository<Bill, DBContext>, IBillRepository
    {
        public BillRepository(DBContext context) : base(context)
        {
        }
    }
}
