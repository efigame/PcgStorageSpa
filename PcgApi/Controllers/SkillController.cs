using PcgApi.Models;
using System.Web.Http;

namespace PcgApi.Controllers
{
    public class SkillController : ApiController
    {

        [Route("api/skill/{skillid}")]
        public IHttpActionResult Post([FromBody]Skill skill)
        {
            skill.SetSelectedAdjustment();

            return Ok();
        }
    }
}