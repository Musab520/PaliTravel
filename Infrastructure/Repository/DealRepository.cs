using Domain.Enum;
using Domain.IRepository;
using Domain.SieveModel;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class DealRepository : IDealRepository
{
    private readonly Context _reserveContext;
    private readonly ModelToDealMapper _mapper;

    public DealRepository(Context context, ModelToDealMapper mapper)
    {
        _reserveContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public async Task<DealModel?> Insert(DealModel deal)
    {
        Deal baseDeal = _mapper.MapToDeal(deal);

        await _reserveContext.AddAsync(baseDeal);

        await _reserveContext.SaveChangesAsync();

        DealModel dealModel = _mapper.MapToModel(baseDeal);

        return dealModel;
    }

    public void Update(DealModel deal)
    {
        Deal baseDeal = _mapper.MapToDeal(deal);
        _reserveContext.Update(baseDeal);
        _reserveContext.SaveChanges();
    }

    public void Delete(DealModel deal)
    {
        Deal baseDeal = _mapper.MapToDeal(deal);
        _reserveContext.Remove(baseDeal);
        _reserveContext.SaveChanges();
    }

    public async Task<DealModel?> GetById(Guid id)
    {
        Deal? deal = await _reserveContext.FindAsync<Deal>(id);
        if (deal == null)
        {
            return null;
        }
        DealModel dealModel = _mapper.MapToModel(deal);
        return dealModel;
    }
}