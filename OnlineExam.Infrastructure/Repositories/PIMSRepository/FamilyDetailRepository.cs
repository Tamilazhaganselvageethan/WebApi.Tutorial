using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class FamilyDetailRepository : GenericRepository<FamilyDetails>, IFamilyDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public FamilyDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(FamilyDetails entity)
        {
            _dbContect.Family_Details_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
