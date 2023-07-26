using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QuoteApi.Services;

namespace QuoteApi.Authorization
{
    public class FakeAuthorizationHandler : AuthorizationHandler<IAuthorizationRequirement>
    {
        private readonly IFakeLoginService _fakeLoginService;

        public FakeAuthorizationHandler(IFakeLoginService fakeLoginService)
        {
            _fakeLoginService = fakeLoginService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IAuthorizationRequirement requirement)
        {
            if (_fakeLoginService.IsUserLoggedIn())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
