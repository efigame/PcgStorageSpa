using System.Runtime.Serialization;

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
        public int AdventurePathId { get; set; }

        public Deck()
        {
        }

        internal Deck(DataAccess.Dto.AdventureDeck deck) : this(deck, true)
        {
        }

        internal Deck(DataAccess.Dto.AdventureDeck deck, bool deepObjects)
        {
            Id = deck.Id;
            Name = deck.Name;
            AdventurePathId = deck.AdventurePathId;

            if (deepObjects)
            {
            }
        }
    }
}