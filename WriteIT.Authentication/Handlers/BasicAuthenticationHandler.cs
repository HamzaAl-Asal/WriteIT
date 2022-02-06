using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace WriteIT.Authentication.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock systemClock
            ) : base(options, logger, encoder, systemClock)
        { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authentication Header not Found !");

            try
            {
                var authHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(':');

                string email = credentials[0];
                string password = credentials[1];

                string user = string.Empty; // get user where email == db email also for the password // string should be the dbset of the user

                if (user == null)
                    return AuthenticateResult.Fail("Invalid email Or Password");
                else
                {
                    var claim = new[] { new Claim(ClaimTypes.Name, "user.Email") };
                    var identity = new ClaimsIdentity(claim, Scheme.Name);
                    var principle = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principle, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("You are Not Authorize");
            }
        }
    }
}
