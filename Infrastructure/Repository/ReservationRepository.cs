using Domain.Enum;
using Domain.IRepository;
using Domain.SieveModel;
using Infrastructure.Mapper;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ReservationRepository : IReservationRepository
{
    private readonly Context _reserveContext;
    private readonly ModelToReservationMapper _mapper;

    public ReservationRepository(Context context, ModelToReservationMapper mapper)
    {
        _reserveContext = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    }
    
    public async Task<ReservationModel?> Reserve(ReservationModel reservation)
    {
        Reservation baseReservation = _mapper.MapToReservation(reservation);
        Room? room = await _reserveContext.Room.FindAsync(reservation.RoomId);
        
        if (room == null)
        {
            return null;
        }
        
        if (room.Availability != Availability.Free.ToString())
        {
            return null;
        }
        
        using var transaction = await _reserveContext.Database.BeginTransactionAsync();
        
        try
        {
            room.Availability = Availability.Reserved.ToString();
            baseReservation.PricePurchased = room.Price;
            _reserveContext.Room.Update(room);
        
            await _reserveContext.Reservation.AddAsync(baseReservation);
            await _reserveContext.SaveChangesAsync();
        
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
        
        return _mapper.MapToModel(baseReservation);
    }


    public async Task<ReservationModel?> Insert(ReservationModel reservation)
    {
        Reservation baseReservation = _mapper.MapToReservation(reservation);

        await _reserveContext.AddAsync(baseReservation);

        await _reserveContext.SaveChangesAsync();

        ReservationModel reservationModel = _mapper.MapToModel(baseReservation);

        return reservationModel;
    }

    public void Update(ReservationModel reservation)
    {
        Reservation baseReservation = _mapper.MapToReservation(reservation);
        _reserveContext.Update(baseReservation);
        _reserveContext.SaveChanges();
    }

    public void Delete(ReservationModel reservation)
    {
        Reservation baseReservation = _mapper.MapToReservation(reservation);
        _reserveContext.Remove(baseReservation);
        _reserveContext.SaveChanges();
    }

    public async Task<ReservationModel?> GetById(Guid id)
    {
        Reservation? reservation = await _reserveContext.FindAsync<Reservation>(id);
        if (reservation == null)
        {
            return null;
        }
        ReservationModel reservationModel = _mapper.MapToModel(reservation);
        return reservationModel;
    }
}