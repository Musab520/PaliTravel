using Domain.SieveModel;

namespace Domain.IService;

public interface IConfirmationService
{
    Task<ConfirmationModel?> Insert(ConfirmationModel confirmationModel);
    void Update(ConfirmationModel confirmationModel);
    void Delete(ConfirmationModel confirmationModel);
    ConfirmationModel GetById(int id);
}