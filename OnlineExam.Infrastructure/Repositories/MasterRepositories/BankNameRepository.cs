using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class BankNameRepository : GenericRepository<BankNameDetails>, IBankNameRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public BankNameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(BankNameDetails entity)
        {
            _dbContect.BanknameDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
