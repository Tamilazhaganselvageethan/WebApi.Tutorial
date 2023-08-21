using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class AddressDetailRepository : GenericRepository<AddressDetails>, IAddressDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public AddressDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task Update(AddressDetails entity)
        {
            _dbContect.Address_Detail_tbl.Update(entity);
            _dbContect.SaveChanges();
        }



    }
}
