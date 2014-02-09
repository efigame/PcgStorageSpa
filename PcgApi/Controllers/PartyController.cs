using PcgApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PcgApi.Controllers
{
    public class PartyController : ApiController
    {
        // GET api/{userid}/party
        [Route("api/{userid}/party")]
        public IEnumerable<Party> GetParties(int userId)
        {
            var parties = new List<Party>();

            var partyList = DataAccess.Dto.Party.All(userId);
            parties.AddRange(partyList.Select(p => new Party(p)));

            return parties;
        }

        // GET api/party/{partyid}
        [Route("api/party/{partyid}")]
        public Party Get(int partyId)
        {
            var party = DataAccess.Dto.Party.Get(partyId);
            return new Party(party);
        }

        [Route("api/party/{partyid}")]
        public IHttpActionResult Post([FromBody]Party party)
        {
            party.Update();

            return Ok();
        }
    }
}