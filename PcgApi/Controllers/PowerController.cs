using PcgApi.Models;
using System.Web.Http;

namespace PcgApi.Controllers
{
    public class PowerController : ApiController
    {

        [Route("api/power/{powerid}")]
        public IHttpActionResult Post([FromBody]Power power)
        {
            power.SetSelectedPower();

            return Ok();
        }
    }
}