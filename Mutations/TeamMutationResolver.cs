using GraphQLDemo.Types;

namespace GraphQLDemo.Mutations;

[ExtendObjectType("Mutation")]
public class TeamMutationResolver
{
    public TeamType CreateTeam(string name) => new(name);
}