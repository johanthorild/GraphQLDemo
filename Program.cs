using GraphQLDemo.Mutations;
using GraphQLDemo.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddType<TeamQueryResolver>()
    .AddType<PlayerQueryResolver>()
    .AddMutationType(q => q.Name("Mutation"))
    .AddType<TeamMutationResolver>()
    .AddType<PlayerMutationResolver>()
    .ModifyRequestOptions(
        opt =>
            opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());

var app = builder.Build();

app.MapGraphQL();

app.Run();
