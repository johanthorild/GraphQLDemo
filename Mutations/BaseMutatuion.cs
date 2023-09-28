namespace GraphQLDemo.Mutations;

public sealed class Mutation
{
    public TeamMutation Team => new();
    public PlayerMutation Player => new();
}