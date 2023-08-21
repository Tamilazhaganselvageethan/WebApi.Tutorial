using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IEducationDetailRepository : IGenericRepository<EducationDetails>
    {
        Task Update(EducationDetails entity);
    }
}
