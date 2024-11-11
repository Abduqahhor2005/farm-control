using FarmControl.Features.Commands.Field.FieldCommandRequest;
using FarmControl.Features.Entities;
using FarmControl.Features.Queries.Field.FieldViewModels;

namespace FarmControl.Base.Extensions.Mappers;

public static class FieldMappingExtension
{
    public static GetFieldViewModel ToReadInfo(this Field field)
    {
        return new()
        {
            Id = field.Id,
            FieldBaseInfo = new()
            {
                Location = field.Location,
                Area = field.Area,
                FarmerId = field.FarmerId
            }
        };
    }
    
    public static GetFieldDetailViewModel ToReadDetailInfo(this Field field)
    {
        return new()
        {
            Id = field.Id,
            FieldBaseInfo = new()
            {
                Location = field.Location,
                Area = field.Area,
                FarmerId = field.FarmerId
            }
        };
    }

    public static Field ToField(this CreateFieldRequest request)
    {
        return new()
        {
            Location = request.FieldBaseInfo.Location,
            Area = request.FieldBaseInfo.Area,
            FarmerId = request.FieldBaseInfo.FarmerId
        };
    }

    public static Field ToUpdatedField(this Field field, UpdateFieldRequest request)
    {
        field.Version++;
        field.UpdatedAt = DateTime.UtcNow;
        field.Location = request.FieldBaseInfo.Location;
        field.Area = request.FieldBaseInfo.Area;
        field.FarmerId = request.FieldBaseInfo.FarmerId;
        return field;
    }

    public static Field ToDeletedField(this Field field)
    {
        field.IsDeleted = true;
        field.DeletedAt = DateTime.UtcNow;
        field.UpdatedAt = DateTime.UtcNow;
        field.Version++;
        return field;
    }
}