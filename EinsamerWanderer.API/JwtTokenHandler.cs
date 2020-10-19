using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

namespace EinsamerWanderer.API
{
    public class JwtTokenHandler : JwtBearerHandler
    {
        public JwtTokenHandler(IOptionsMonitor<JwtBearerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string authorization = Request.Headers[HeaderNames.Authorization];
            string token = null;
            if (authorization?.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                token = authorization.Substring("Bearer ".Length).Trim();
            }

            if (token is null)
            {
                return AuthenticateResult.Fail("No bearer token in url");
            }
            var result = await new HttpClient().GetAsync($"http://localhost:5020/token/?token={token}");
            if (result.StatusCode != HttpStatusCode.OK)
            {
                return AuthenticateResult.Fail("Token not valid");
            }

            var secret = await result.Content.ReadAsStringAsync();
            Options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            return await base.HandleAuthenticateAsync();
        }
    }
}