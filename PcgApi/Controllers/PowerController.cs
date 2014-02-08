using PcgApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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