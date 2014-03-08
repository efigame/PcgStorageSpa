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

            WeaponCards.AddRange(DataAccess.Dto.WeaponCard.All().Select(c => new Card(c, false)));
            SpellCards.AddRange(DataAccess.Dto.SpellCard.All().Select(c => new Card(c, false)));
            ArmorCards.AddRange(DataAccess.Dto.ArmorCard.All().Select(c => new Card(c, false)));
            ItemCards.AddRange(DataAccess.Dto.ItemCard.All().Select(c => new Card(c, false)));
            AllyCards.AddRange(DataAccess.Dto.AllyCard.All().Select(c => new Card(c, false)));
            BlessingCards.AddRange(DataAccess.Dto.BlessingCard.All().Select(c => new Card(c, false)));
        }
    }
}