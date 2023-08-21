using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class AccountDetailRepository : GenericRepository<AccountDetails>, IAccountDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public AccountDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task Update(AccountDetails entity)
        {
            _dbContect.Account_Details_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
