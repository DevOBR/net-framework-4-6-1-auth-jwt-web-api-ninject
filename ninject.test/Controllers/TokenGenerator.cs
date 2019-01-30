using System;
using System.Security.Claims;

namespace ninject.test.Controllers
{
    public class TokenGenerator
    {
        public static string GenerateTokenJwt(string username)
        {
            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity
            (
                new[] 
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }
            );

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken
            (
                audience: ConfigurationService.GetJwtConfigurationObject().audienceToken,
                issuer: ConfigurationService.GetJwtConfigurationObject().issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(ConfigurationService.GetJwtConfigurationObject().expireTime)),
                signingCredentials: ConfigurationService.GetJwtConfigurationObject().signingCredentials
            );

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
