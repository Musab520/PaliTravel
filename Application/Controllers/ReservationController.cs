using Application.DTOModels.Hotel;
using Application.DTOModels.Reservation;
using Application.Mapper;
using Domain.IService;
using Domain.SieveModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/reservation")]
public class ReservationController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly IReservationService _reservationService;
    private readonly IValidator<ReservationModel> _validator;
    private readonly ModelToReservationDtoMapper _mapper;
    
    public ReservationController(IReservationService reservationService, IConfiguration configuration, IValidator<ReservationModel> validator, ModelToReservationDtoMapper modelToReservationDtoMapper)
    {
        _reservationService = reservationService ?? throw new ArgumentNullException(nameof(reservationService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToReservationDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> CreateReservation(ReservationUpsertDto reservationUpsertDto) {
        ReservationModel reservationModel = _mapper.MapUpsertToModel(reservationUpsertDto);
        var modelState = _validator.Validate(reservationModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        ReservationModel? reservationModelNew = await _reservationService.Insert(reservationModel);
        if (reservationModelNew == null)
        {
            return BadRequest(new { Message = "Reservation insertion failed. Please try again." });
        }
        return Ok(reservationModelNew);
    }

}