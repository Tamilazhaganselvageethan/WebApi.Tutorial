using OnlineExam.Application.Contracts.IPageConfigurationService;
using OnlineExam.Domain.Model.PageDetails;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.PageConfigurationService
{
    public class SubPageFieldService : GenericRepository<M_SubPageFields>, ISubPageFieldService
    {
        private readonly ApplicationDbContext _dbContect;

        public SubPageFieldService(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(M_SubPageFields entity)
        {
            _dbContect.SubPageField.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
