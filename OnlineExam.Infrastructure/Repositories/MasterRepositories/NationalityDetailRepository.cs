using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class NationalityDetailRepository : GenericRepository<NationalityDetail>, INationalityDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public NationalityDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(NationalityDetail entity)
        {
            _dbContect.nationalityDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
