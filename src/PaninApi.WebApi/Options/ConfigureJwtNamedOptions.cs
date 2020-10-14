using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaninApi.Infrastructure.Options;

namespace PaninApi.WebApi.Options
{
    public class ConfigureJwtNamedOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtAuthoritiesOption _jwtAuthority;
        
        public ConfigureJwtNamedOptions(IOptions<JwtAuthoritiesOption> jwtAuthorities)
        {
            _jwtAuthority = jwtAuthorities.Value;
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(JwtBearerDefaults.AuthenticationScheme, options);
        }

        public void Configure(string name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidAudience = _jwtAuthority.Authorities[name].Audience,
                ValidIssuer = _jwtAuthority.Authorities[name].Issuer
            };

            options.Authority = _jwtAuthority.Authorities[name].Authority;
            options.Audience = _jwtAuthority.Authorities[name].Audience;
        }
    }
}