using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Card
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int DeckId { get; set; }
        [DataMember]
        public CardType CardType { get; set; }

        public Card()
        {
        }

        internal Card(DataAccess.Dto.Card card) : this(card, false)
        {
        }

        internal Card(DataAccess.Dto.Card card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.DeckId;
            CardType = new CardType(card.CardType);

            if (deepObjects)
            {
            }
        }
    }
}