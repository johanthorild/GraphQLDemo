using GraphQLDemo.Server.Data;
using GraphQLDemo.Server.Mutations;
using GraphQLDemo.Server.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClubContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ClubDatabase"));
});

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterDbContext<ClubContext>()
    .ModifyRequestOptions(
        opt =>
            opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());

var app = builder.Build();

app.MapGraphQL();

app.Run();
