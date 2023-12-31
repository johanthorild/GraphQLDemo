using GraphQLDemo.Data;
using GraphQLDemo.Mutations;
using GraphQLDemo.Queries;
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
