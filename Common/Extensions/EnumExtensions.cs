public static class EnumExtensions
{
    private static Random _random = new();

    public static T? PickRandomEnumValue<T>() where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException($"{typeof(T).FullName} is not an enum type.");

        var values = Enum.GetValues(typeof(T)).OfType<T>().ToList();
        
        if (values.Count == 0)
            throw new ArgumentException($"{typeof(T).FullName} does not contain any valid enum values.");

        return values[_random.Next(values.Count)];
    }
}
