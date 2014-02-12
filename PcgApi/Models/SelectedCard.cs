using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class SelectedCard
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PartyCharacterId { get; set; }
        [DataMember]
        public int CardId { get; set; }
        [DataMember]
        public int Count { get; set; }

        public SelectedCard()
        {
        }

        internal SelectedCard(DataAccess.Dto.CharacterDeck deck, int partyCharacterId) : this(deck, partyCharacterId, true)
        {
        }

        internal SelectedCard(DataAccess.Dto.CharacterDeck deck, int partyCharacterId, bool deepObjects)
        {
            Id = deck.Id;
            PartyCharacterId = partyCharacterId;
            CardId = deck.CardId;
            Count = deck.Count;

            if (deepObjects)
            {
            }
        }
    }
}