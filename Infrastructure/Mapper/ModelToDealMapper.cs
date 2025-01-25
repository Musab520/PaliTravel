using Domain.Model;
using Riok.Mapperly.Abstractions;
using Infrastructure.Model;

namespace Infrastructure.Mapper;

[Mapper]
public partial class ModelToDealMapper
{
    public partial Deal MapToDeal(DealModel dealModel);

    public partial DealModel MapToModel(Deal deal);
}