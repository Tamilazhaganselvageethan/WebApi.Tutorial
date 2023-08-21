using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class CollegeDetailRepository : GenericRepository<CollegeDetails>, ICollegeDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public CollegeDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(CollegeDetails entity)
        {
            _dbContect.collegeDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
