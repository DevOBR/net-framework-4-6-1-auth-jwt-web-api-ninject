using ninject.test.Models;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace ninject.test.Controllers
{

    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity1 = HttpContext.Current.User.Identity;
            var identity2 = Thread.CurrentPrincipal.Identity;
            return Ok(new string[] 
            {
                $" IPrincipal-user: {identity1.Name} - IsAuthenticated: {identity1.IsAuthenticated}",
                $" IPrincipal-user: {identity2.Name} - IsAuthenticated: {identity2.IsAuthenticated}"
            });
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //TODO: Validate credentials Correctly, this code is only for demo !!
            bool isCredentialValid = (login.Password == "123456");
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
