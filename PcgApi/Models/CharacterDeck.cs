using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class CharacterDeck
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public Card Card { get; set; }

        public CharacterDeck()
        {
        }

        internal CharacterDeck(DataAccess.Dto.CharacterDeck characterDeck) : this(characterDeck, false)
        {
        }

        internal CharacterDeck(DataAccess.Dto.CharacterDeck characterDeck, bool deepObjects)
        {
            Id = characterDeck.Id;
            Count = characterDeck.Count;
            Card = new Card(characterDeck.Card);

            if (deepObjects)
            {
            }
        }
    }
}