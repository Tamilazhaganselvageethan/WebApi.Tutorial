using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class RelationshipDetailRepository : GenericRepository<RelationshipDetails>, IRelationshipDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public RelationshipDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(RelationshipDetails entity)
        {
            _dbContect.relationshipDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
