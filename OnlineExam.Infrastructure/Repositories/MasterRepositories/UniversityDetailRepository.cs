using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class UniversityDetailRepository : GenericRepository<UniversityDetail>, IUniversityDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public UniversityDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(UniversityDetail entity)
        {
            _dbContect.universityDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
