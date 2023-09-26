using GraphQLDemo.Types;
using GraphQLDemo.Common.Enums;

namespace GraphQLDemo.Mutations;

[ExtendObjectType("Mutation")]
public class PlayerMutationResolver
{
    public PlayerType CreatePlayer(
        string firstName,
        string lastName,
        PlayerPosition? position,
        int shirtNumber,
        Guid teamId)
    => new(
        firstName,
        lastName,
        position,
        shirtNumber,
        teamId);
}