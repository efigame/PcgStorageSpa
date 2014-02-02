using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Party
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public List<Character> Characters { get; set; }

        internal Party(DataAccess.Dto.Party party) : this(party, true)
        {
        }
        internal Party(DataAccess.Dto.Party party, bool deepObjects)
        {
            Id = party.Id;
            Name = party.Name;
            UserId = party.PcgUserId;
            Characters = new List<Character>();

            if (deepObjects)
            {
                var characters = DataAccess.Dto.PartyCharacter.All(Id).ToList();
                Characters.AddRange(characters.Select(c => new Character(c)));
            }
        }
    }
}