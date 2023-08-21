using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IContectDetailRepository : IGenericRepository<ContactDetails>
    {
        Task Update(ContactDetails entity);
    }
}
