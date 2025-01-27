
using Domain.IRepository;
using Domain.SieveModel;
using Domain.IService;

namespace Domain.Service;

public class DealService : IDealService
{
    private readonly IDealRepository _dealRepository;

    public DealService(IDealRepository dealRepository)
    {
        _dealRepository = dealRepository ?? throw new ArgumentNullException(nameof(dealRepository));
    }
    
    public async Task<DealModel?> Insert(DealModel dealModel)
    {
        return await _dealRepository.Insert(dealModel);
    }

    public void Update(DealModel dealModel)
    {
        throw new NotImplementedException();
    }

    public void Delete(DealModel dealModel)
    {
        throw new NotImplementedException();
    }

    public DealModel GetById(int id)
    {
        throw new NotImplementedException();
    }
}