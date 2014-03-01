using DataAccess.Dto;
using PcgApi.Models;
using System.Web.Http;

namespace PcgApi.Controllers
{
    public class LoginController : ApiController
    {
        // POST api/login
        [Route("api/login")]
        public IHttpActionResult Post([FromBody]User user)
        {
            var pcgUser = PcgUser.Get(user.Email, user.Password);
            if (pcgUser != null) return Ok(new User(pcgUser));
            return NotFound();
        }
    }
}