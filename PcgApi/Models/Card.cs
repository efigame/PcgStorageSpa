using System.Runtime.Serialization;

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

        public Card()
        {
        }

        internal Card(DataAccess.Dto.WeaponCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
        internal Card(DataAccess.Dto.SpellCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
        internal Card(DataAccess.Dto.ArmorCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
        internal Card(DataAccess.Dto.ItemCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
        internal Card(DataAccess.Dto.AllyCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
        internal Card(DataAccess.Dto.BlessingCard card, bool deepObjects)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.AdventureDeckId;

            if (deepObjects)
            {
            }
        }
    }
}