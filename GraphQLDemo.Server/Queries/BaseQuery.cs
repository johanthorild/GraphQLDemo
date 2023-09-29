namespace GraphQLDemo.Server.Queries;

public sealed class Query
{
    public TeamQuery Team => new();
    public PlayerQuery Player => new();
}