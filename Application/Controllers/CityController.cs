using Application.DTOModels.City;
using Application.Mapper;
using Domain.IService;
using Domain.SieveModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/city")]
public class CityController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly ICityService _cityService;
    private readonly IValidator<CityModel> _validator;
    private readonly ModelToCityDtoMapper _mapper;
    
    public CityController(ICityService cityService, IConfiguration configuration, IValidator<CityModel> validator, ModelToCityDtoMapper modelToCityDtoMapper)
    {
        _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToCityDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> CreateCity(CityUpsertDto cityUpsertDto) {
        CityModel cityModel = _mapper.MapUpsertToModel(cityUpsertDto);
        var modelState = _validator.Validate(cityModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        CityModel? cityModelNew = await _cityService.Insert(cityModel);
        if (cityModelNew == null)
        {
            return BadRequest(new { Message = "Hotel insertion failed. Please try again." });
        }
        return Ok(cityModelNew);
    }

}