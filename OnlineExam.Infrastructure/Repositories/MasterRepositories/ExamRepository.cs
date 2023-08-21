using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class ExamRepository : GenericRepository<ExamDetails>, IExamRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public ExamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(ExamDetails entity)
        {
            _dbContect.examDetails.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
