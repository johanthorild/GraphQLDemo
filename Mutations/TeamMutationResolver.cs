using GraphQLDemo.Types;

namespace GraphQLDemo.Mutations;

[MutationType()]
public class TeamMutationResolver
{
    public TeamType CreateTeam(string name) => new(name);
}