public static class FilePathGenerator
{
    public static string GeneratePathFromUuids(params object[] instances)
    {
        var uuids = instances.Select(instance =>
        {
            var uuidProperty = instance.GetType().GetProperty("Uuid");
            return uuidProperty?.GetValue(instance)?.ToString();

        }).Where(uuid => !string.IsNullOrEmpty(uuid)).ToList();

        return string.Join("/", uuids);
    }
}