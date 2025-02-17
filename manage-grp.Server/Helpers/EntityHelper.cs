using manage_grp.Server.Enums;

public static class EntityHelper
{
    public static void UpdateEntityFromDto<T, TDto>( UpdateEntityFromDtoAction action, T entity, TDto dto)
    {
        var entityProperties = typeof(T).GetProperties();
        var dtoProperties = typeof(TDto).GetProperties();

        foreach (var entityProperty in entityProperties)
        {
            var dtoProperty = dtoProperties.FirstOrDefault(p => p.Name == entityProperty.Name);

            if (dtoProperty != null)
            {
                var value = dtoProperty.GetValue(dto);

                if (value != null)
                {
                    entityProperty.SetValue(entity, value);
                }
            }
        }

        var createdAtProperty = entityProperties.FirstOrDefault(p => p.Name == "CreatedAt");
        var updatedAtProperty = entityProperties.FirstOrDefault(p => p.Name == "UpdatedAt");

        var now = DateTime.UtcNow;

        if (action == UpdateEntityFromDtoAction.Create)
        {
            createdAtProperty?.SetValue(entity, now);
            updatedAtProperty?.SetValue(entity, now);
        }
        else if (action == UpdateEntityFromDtoAction.Update)
        {
            updatedAtProperty?.SetValue(entity, now);
        }
    }
}
