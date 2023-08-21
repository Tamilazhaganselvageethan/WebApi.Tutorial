using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IFamilyDetailRepository : IGenericRepository<FamilyDetails>
    {
        Task Update(FamilyDetails entity);
    }
}
