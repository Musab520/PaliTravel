using Domain.Enum;
using Domain.IRepository;
using Domain.SieveModel;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ConfirmationRepository : IConfirmationRepository
{
    private readonly Context _reserveContext;
    private readonly ModelToConfirmationMapper _mapper;

    public ConfirmationRepository(Context context, ModelToConfirmationMapper mapper)
    {
        _reserveContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }

    public async Task<ConfirmationModel?> Insert(ConfirmationModel confirmation)
    {
        Confirmation baseConfirmation = _mapper.MapToConfirmation(confirmation);

        await _reserveContext.AddAsync(baseConfirmation);

        await _reserveContext.SaveChangesAsync();

        ConfirmationModel confirmationModel = _mapper.MapToModel(baseConfirmation);

        return confirmationModel;
    }

    public void Update(ConfirmationModel confirmation)
    {
        Confirmation baseConfirmation = _mapper.MapToConfirmation(confirmation);
        _reserveContext.Update(baseConfirmation);
        _reserveContext.SaveChanges();
    }

    public void Delete(ConfirmationModel confirmation)
    {
        Confirmation baseConfirmation = _mapper.MapToConfirmation(confirmation);
        _reserveContext.Remove(baseConfirmation);
        _reserveContext.SaveChanges();
    }

    public async Task<ConfirmationModel?> GetById(Guid id)
    {
        Confirmation? confirmation = await _reserveContext.FindAsync<Confirmation>(id);
        if (confirmation == null)
        {
            return null;
        }
        ConfirmationModel confirmationModel = _mapper.MapToModel(confirmation);
        return confirmationModel;
    }
}