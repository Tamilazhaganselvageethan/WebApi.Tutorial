using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class GradeDetailRepository : GenericRepository<GradeDetails>, IGradeRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public GradeDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(GradeDetails entity)
        {
            _dbContect.gradeDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
