using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class AvailableCards
    {
        [DataMember]
        public List<Card> WeaponCards { get; set; }
        [DataMember]
        public List<Card> SpellCards { get; set; }
        [DataMember]
        public List<Card> ArmorCards { get; set; }
        [DataMember]
        public List<Card> ItemCards { get; set; }
        [DataMember]
        public List<Card> AllyCards { get; set; }
        [DataMember]
        public List<Card> BlessingCards { get; set; }

        public AvailableCards()
        {
            WeaponCards = new List<Card>();
            SpellCards = new List<Card>();
            ArmorCards = new List<Card>();
            ItemCards = new List<Card>();
            AllyCards = new List<Card>();
            BlessingCards = new List<Card>();

            var availableCards = DataAccess.Dto.Card.All();

            WeaponCards.AddRange(availableCards.Where(c => c.CardTypeId == 10).Select(c => new Card(c)));
            SpellCards.AddRange(availableCards.Where(c => c.CardTypeId == 11).Select(c => new Card(c)));
            ArmorCards.AddRange(availableCards.Where(c => c.CardTypeId == 13).Select(c => new Card(c)));
            ItemCards.AddRange(availableCards.Where(c => c.CardTypeId == 14).Select(c => new Card(c)));
            AllyCards.AddRange(availableCards.Where(c => c.CardTypeId == 15).Select(c => new Card(c)));
            BlessingCards.AddRange(availableCards.Where(c => c.CardTypeId == 16).Select(c => new Card(c)));
        }
    }
}