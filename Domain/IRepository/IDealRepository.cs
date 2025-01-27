using Domain.SieveModel;

namespace Domain.IRepository;

public interface IDealRepository
{
    Task<DealModel?> Insert(DealModel deal);
    void Update(DealModel deal);
    void Delete(DealModel deal);
    Task<DealModel?> GetById(Guid id);

}