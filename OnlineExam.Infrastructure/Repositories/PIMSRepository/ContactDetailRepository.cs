using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class ContectDetailRepository : GenericRepository<ContactDetails>, IContectDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public ContectDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(ContactDetails entity)
        {
            _dbContect.Contact_Detail_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
