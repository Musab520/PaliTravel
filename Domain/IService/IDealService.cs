using Domain.Model;

namespace Domain.IService;

public interface IDealService
{
    Task<DealModel?> Insert(DealModel dealModel);
    void Update(DealModel dealModel);
    void Delete(DealModel dealModel);
    DealModel GetById(int id);
}