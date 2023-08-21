using OnlineExam.Application.Contracts.IPageConfigurationService;
using OnlineExam.Domain.Model.PageDetails;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.PageConfigurationService
{
    public class SubPageDetailService : GenericRepository<M_SubPageDetails>, ISubPageDetailService
    {
        private readonly ApplicationDbContext _dbContect;

        public SubPageDetailService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(M_SubPageDetails entity)
        {
            _dbContect.SubPageDetails.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
