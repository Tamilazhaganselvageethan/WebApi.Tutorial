using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IAddressDetailRepository : IGenericRepository<AddressDetails>
    {
        Task Update(AddressDetails entity);
    }
}
