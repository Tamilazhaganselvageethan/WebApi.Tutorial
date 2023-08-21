using OnlineExam.Application.Contracts.IPageConfigurationService;
using OnlineExam.Domain.Model.PageDetails;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.PageConfigurationService
{
    public class MPageDetailServices : GenericRepository<M_PageDetails>, IMPageDetailService
    {
        private readonly ApplicationDbContext _dbContect;

        public MPageDetailServices(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(M_PageDetails entity)
        {
            _dbContect.M_PageDetails_Tbl.Update(entity);
            _dbContect.SaveChanges();
        }


    }
}
