using CodeCareer.Application.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.PostgreSQL.Authentication
{
    public class JWTProvider : IJWTProvider
    {
        private readonly JWTOption _jwtOption;

        public JWTProvider(IOptions<JWTOption> jwtOption)
        {
            _jwtOption = jwtOption.Value;
        }

        public string GenerateToken(IdentityUser user, IList<string> UserRoles)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id)
            };
/*            foreach (var role in UserRoles) {
                authClaims.Add(new Claim("role", role));
            }*/

            var signingCredencials = new SigningCredentials
            (
                new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_jwtOption.SecretKey)
                ),
                SecurityAlgorithms.HmacSha256Signature
            );

            var token = new JwtSecurityToken
            (
                _jwtOption.Issuer,
                _jwtOption.Audience,
                authClaims,
                null,
                DateTime.Now.AddHours(1),
                signingCredencials
            );
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
