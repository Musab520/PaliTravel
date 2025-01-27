using Application.DTOModels.Hotel;
using Application.Mapper;
using Domain.IService;
using Domain.SieveModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/hotel")]
public class HotelController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly IHotelService _hotelService;
    private readonly IValidator<HotelModel> _validator;
    private readonly ModelToHotelDtoMapper _mapper;
    
    public HotelController(IHotelService hotelService, IConfiguration configuration, IValidator<HotelModel> validator, ModelToHotelDtoMapper modelToHotelDtoMapper)
    {
        _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToHotelDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> CreateHotel(HotelUpsertDto hotelUpsertDto) {
        HotelModel hotelModel = _mapper.MapUpsertToModel(hotelUpsertDto);
        var modelState = _validator.Validate(hotelModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        HotelModel? hotelModelNew = await _hotelService.Insert(hotelModel);
        if (hotelModelNew == null)
        {
            return BadRequest(new { Message = "Hotel insertion failed. Please try again." });
        }
        return Ok(hotelModelNew);
    }

}