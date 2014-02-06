﻿using PcgApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PcgApi.Controllers
{
    public class CharacterController : ApiController
    {
        // GET api/character/{characterid}
        [Route("api/character/{characterid}")]
        public Character Get(int characterId)
        {
            var partyCharacterData = DataAccess.Dto.PartyCharacter.Get(characterId);
            return new Character(partyCharacterData);
        }

        [Route("api/character/{characterid}")]
        public IHttpActionResult Post([FromBody]Character character)
        {
            character.Update();

            return Ok();
            //if (pcgUser != null) return Ok(new User(pcgUser));
            //return NotFound();
        }

    }
}