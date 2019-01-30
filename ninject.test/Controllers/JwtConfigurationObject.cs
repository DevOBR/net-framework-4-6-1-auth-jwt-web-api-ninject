using Microsoft.IdentityModel.Tokens;

namespace ninject.test.Controllers
{
    public class JwtConfigurationObject
    {
        public string secretKey { get; set; }
        public string audienceToken { get; set; }
        public string issuerToken { get; set; }
        public string expireTime { get; set; }
        public SymmetricSecurityKey securityKey { get; set; }
        public SigningCredentials signingCredentials { get; set; }
    }
}