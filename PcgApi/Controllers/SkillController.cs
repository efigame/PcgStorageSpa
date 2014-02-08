using PcgApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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