using Application.DTOModels.Hotel;
using Application.DTOModels.Confirmation;
using Application.Mapper;
using Domain.IService;
using Domain.SieveModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/confirmation")]
public class ConfirmationController : Controller 
{
    private readonly IConfiguration _configuration;
    private readonly IConfirmationService _confirmationService;
    private readonly IValidator<ConfirmationModel> _validator;
    private readonly ModelToConfirmationDtoMapper _mapper;
    
    public ConfirmationController(IConfirmationService confirmationService, IConfiguration configuration, IValidator<ConfirmationModel> validator, ModelToConfirmationDtoMapper modelToConfirmationDtoMapper)
    {
        _confirmationService = confirmationService ?? throw new ArgumentNullException(nameof(confirmationService));
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _validator = validator;
        _mapper = modelToConfirmationDtoMapper;
    }

    [HttpPost]
    public async Task<ActionResult<Boolean>> Insert(ConfirmationUpsertDto confirmationUpsertDto) {
        ConfirmationModel confirmationModel = _mapper.MapUpsertToModel(confirmationUpsertDto);
        var modelState = _validator.Validate(confirmationModel);
        if (!modelState.IsValid)
        {
            return BadRequest(modelState);
        }

        ConfirmationModel? confirmationModelNew = await _confirmationService.Insert(confirmationModel);
        if (confirmationModelNew == null)
        {
            return BadRequest(new { Message = "Confirmation insertion failed. Please try again." });
        }
        return Ok(confirmationModelNew);
    }

}