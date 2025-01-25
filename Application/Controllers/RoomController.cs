using Application.DTOModels.Hotel;
using Application.DTOModels.Room;
using Application.Mapper;
using Domain.IService;
using Domain.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/room")]
public class RoomController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly IRoomService _roomService;
    private readonly IValidator<RoomModel> _validator;
    private readonly ModelToRoomDtoMapper _mapper;
    
    public RoomController(IRoomService roomService, IConfiguration configuration, IValidator<RoomModel> validator, ModelToRoomDtoMapper modelToRoomDtoMapper)
    {
        _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToRoomDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> CreateRoom(RoomUpsertDto roomUpsertDto) {
        RoomModel roomModel = _mapper.MapUpsertToModel(roomUpsertDto);
        var modelState = _validator.Validate(roomModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        RoomModel? roomModelNew = await _roomService.Insert(roomModel);
        if (roomModelNew == null)
        {
            return BadRequest(new { Message = "Room insertion failed. Please try again." });
        }
        return Ok(roomModelNew);
    }
    
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableRooms([FromQuery] AvailableRoomSieveModel sieveModel)
    {
        // Call the service method to get available rooms with Sieve applied
        List<AvailableRoomModel?> rooms = await _roomService.GetAvailableRoomsAsync(sieveModel);
        if (!rooms.Any()) {
            return BadRequest(new { Message = "An error occured fetching rooms. Please try again." });
        }
        return Ok(rooms);
    }

}