using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IExperienceDetailRepository : IGenericRepository<ExperienceDetails>
    {
        Task Update(ExperienceDetails entity);
    }
}
