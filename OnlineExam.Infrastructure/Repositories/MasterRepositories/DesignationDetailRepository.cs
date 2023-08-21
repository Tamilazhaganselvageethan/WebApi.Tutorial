using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class DesignationDetailRepository : GenericRepository<DesignationGradeDetails>, IDesignationDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public DesignationDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(DesignationGradeDetails entity)
        {
            _dbContect.designationGrades_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
