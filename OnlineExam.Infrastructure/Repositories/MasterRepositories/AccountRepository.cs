using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class AccountRepository : GenericRepository<AccountTypeDetails>, IAccountTypeRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public AccountRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task Update(AccountTypeDetails entity)
        {
            _dbContect.accountTypeDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
