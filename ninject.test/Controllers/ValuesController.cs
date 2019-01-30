using ninject.test.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace ninject.test.Controllers
{
    /// <summary>
    /// Values test controller
    /// </summary>
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        #region Properties
        private readonly IValuesService _valuesService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of dependecies
        /// </summary>
        /// <param name="valuesService"></param>
        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }
        #endregion

        #region WebMethods
        /// <summary>
        /// Get a list of string
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var result = await Task.Run(async () => await this._valuesService.GetValuesAsync());
            await this._valuesService.CreateNewItemInStringListAsync("another string added in get");
            return Ok(result);
        }

        /// <summary>
        /// Get a list of string
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getsingleton")]
        public async Task<IHttpActionResult> GetSingleton()
            => Ok(await Task.Run(() => this._valuesService.GetValuesAsync()));
        #endregion

    }
}
