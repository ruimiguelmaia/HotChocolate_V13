using HotChocolate.Resolvers;
using Microsoft.AspNetCore.Authorization;
using PortalService.Authorization.Requirements;

namespace PortalService.Authorization.Handlers;

public class IsSuperUserHandler : AuthorizationHandler<IsSuperUserRequirement, IResolverContext>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context, 
        IsSuperUserRequirement requirement, 
        IResolverContext resolverContext)
    {
        // This handler is only hit if:  Apply = ApplyPolicy.BeforeResolver
        // If Apply = ApplyPolicy.Validation it is not hit
        context.Succeed(requirement);
    }    
}