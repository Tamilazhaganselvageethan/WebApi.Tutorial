using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class QuestionRepository : GenericRepository<QuestionDetail>, IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public QuestionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(QuestionDetail entity)
        {
            _dbContect.questionDetails.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
