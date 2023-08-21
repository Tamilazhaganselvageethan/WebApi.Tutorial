using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class EducationDetailRepository : GenericRepository<EducationDetails>, IEducationDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public EducationDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(EducationDetails entity)
        {
            _dbContect.Education_Details_tbl.Update(entity);
            _dbContect.SaveChanges();
        }


    }
}
