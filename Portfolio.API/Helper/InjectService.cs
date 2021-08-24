using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Domain.Entities.Jwt;
using System;
using System.Text;

namespace Portfolio.API.Helper
{
    public static class InjectService
    {
        private static readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fmFGn5agHZkuG2N0e1zaEJIQtGVoNN5P"));

        public static void AddJwtValidation(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
             {
                 options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                 options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                 options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
             });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(options =>
           {
               options.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
               options.TokenValidationParameters = tokenValidationParameters;
               options.SaveToken = true;

           });
        }
    }
}
