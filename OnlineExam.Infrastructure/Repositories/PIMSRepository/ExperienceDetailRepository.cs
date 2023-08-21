using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;


namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class ExperienceDetailRepository : GenericRepository<ExperienceDetails>, IExperienceDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public ExperienceDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(ExperienceDetails entity)
        {
            _dbContect.Experience_Details_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
