using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Deck
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int AdventureId { get; set; }

        public Deck()
        {
        }

        internal Deck(DataAccess.Dto.Deck deck) : this(deck, true)
        {
        }

        internal Deck(DataAccess.Dto.Deck deck, bool deepObjects)
        {
            Id = deck.Id;
            Name = deck.Name;
            AdventureId = deck.AdventureId;

            if (deepObjects)
            {
            }
        }
    }
}