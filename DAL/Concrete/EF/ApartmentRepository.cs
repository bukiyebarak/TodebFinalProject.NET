using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EF
{
    public class ApartmentRepository : EFBaseRepository<Apartment, DBContext>, IApartmentRepository
    {
        public ApartmentRepository(DBContext context) : base(context)
        {
        }
    }
}
