using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IPersonalDetailRepository : IGenericRepository<PersonalDetails>
    {
        Task Update(PersonalDetails entity);
    }
}
