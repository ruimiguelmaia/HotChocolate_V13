using Microsoft.AspNetCore.Authorization;
using PortalService;
using PortalService.Authorization.Handlers;
using PortalService.Authorization.Requirements;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isSuperUser", policy =>
        policy.Requirements.Add(new IsSuperUserRequirement())
    );
});

builder.Services.AddSingleton<IAuthorizationHandler, IsSuperUserHandler>();
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();