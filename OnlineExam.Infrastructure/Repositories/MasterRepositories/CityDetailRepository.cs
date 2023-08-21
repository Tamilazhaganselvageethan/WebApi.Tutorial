using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class CityDetailRepository : GenericRepository<CityDetails>, ICityDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public CityDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(CityDetails entity)
        {
            _dbContect.cityDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
