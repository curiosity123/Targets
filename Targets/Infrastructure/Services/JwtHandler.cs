using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Targets.Infrastructure.DTO;
using Targets.Infrastructure.Extensions;
using Targets.Infrastructure.Services.Interfaces;
using Targets.Settings;

namespace Targets.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHandler(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public JwtDTO CreateToken(Guid userId, string role)
        {

            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_jwtSettings.ExpiryMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var iat = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payload = new JwtPayload
            {
                {"sub", userId},
                {"iss", _jwtSettings.Issuer},
                {"iat", iat},
                {"exp", exp},
                {"unique_name", userId},
            };
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(new JwtHeader(signingCredentials), payload);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);


            return new JwtDTO
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}
