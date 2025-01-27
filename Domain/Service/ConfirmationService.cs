
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;

namespace Domain.Service;

public class ConfirmationService : IConfirmationService
{
    private readonly IConfirmationRepository _confirmationRepository;

    public ConfirmationService(IConfirmationRepository confirmationRepository)
    {
        _confirmationRepository = confirmationRepository ?? throw new ArgumentNullException(nameof(confirmationRepository));
    }
    
    public async Task<ConfirmationModel?> Insert(ConfirmationModel confirmationModel)
    {
        return await _confirmationRepository.Insert(confirmationModel);
    }

    public void Update(ConfirmationModel confirmationModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(ConfirmationModel confirmationModel)
    {
        throw new NotImplementedException();
    }

    public ConfirmationModel GetById(int id)
    {
        throw new NotImplementedException();
    }
}