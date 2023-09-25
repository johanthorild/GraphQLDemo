namespace GraphQLDemo.Extensions;

public static class ListExtensions
{
    public static T PopRandom<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
            throw new InvalidOperationException("The list is empty.");

        int index = new Random().Next(list.Count);
        T item = list[index];
        list.RemoveAt(index);
        return item;
    }
}