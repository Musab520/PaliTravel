using Domain.SieveModel;

namespace Domain.IRepository;

public interface IConfirmationRepository
{
    Task<ConfirmationModel?> Insert(ConfirmationModel deal);
    void Update(ConfirmationModel deal);
    void Delete(ConfirmationModel deal);
    Task<ConfirmationModel?> GetById(Guid id);

}