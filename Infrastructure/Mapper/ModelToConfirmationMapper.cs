using Domain.SieveModel;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToConfirmationMapper
{
    public partial Confirmation MapToConfirmation(ConfirmationModel confirmationModel);

    public partial ConfirmationModel MapToModel(Confirmation confirmation);
}