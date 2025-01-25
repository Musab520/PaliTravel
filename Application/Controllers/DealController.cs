using Application.DTOModels.Hotel;
using Application.DTOModels.Deal;
using Application.Mapper;
using Domain.IService;
using Domain.Model;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/deal")]
public class DealController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly IDealService _dealService;
    private readonly IValidator<DealModel> _validator;
    private readonly ModelToDealDtoMapper _mapper;
    
    public DealController(IDealService dealService, IConfiguration configuration, IValidator<DealModel> validator, ModelToDealDtoMapper modelToDealDtoMapper)
    {
        _dealService = dealService ?? throw new ArgumentNullException(nameof(dealService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToDealDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> Insert(DealUpsertDto dealUpsertDto) {
        DealModel dealModel = _mapper.MapUpsertToModel(dealUpsertDto);
        var modelState = _validator.Validate(dealModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        DealModel? dealModelNew = await _dealService.Insert(dealModel);
        if (dealModelNew == null)
        {
            return BadRequest(new { Message = "Deal insertion failed. Please try again." });
        }
        return Ok(dealModelNew);
    }

}