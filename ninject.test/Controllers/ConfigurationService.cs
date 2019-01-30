using Microsoft.IdentityModel.Tokens;
using System.Configuration;

namespace ninject.test.Controllers
{
    public class ConfigurationService
    {

        public static JwtConfigurationObject GetJwtConfigurationObject()
        {
            var jwtResult = new JwtConfigurationObject
            {
                secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"],
                audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
                issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"],
                expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"],
            };

            jwtResult.securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(jwtResult.secretKey));
            jwtResult.signingCredentials = new SigningCredentials(jwtResult.securityKey, SecurityAlgorithms.HmacSha256Signature);

            return jwtResult;
        }
    }
}