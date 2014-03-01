using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeckId { get; set; }
        public int CardTypeId { get; set; }
        public Deck Deck { get; set; }
        public CardType CardType { get; set; }

        public static Card Get(int id)
        {
            Card card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.cards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new Card(cardData);
            }

            return card;
        }
        public static List<Card> All()
        {
            var cards = new List<Card>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.cards.ToList();
                cards.AddRange(all.Select(a => new Card(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.cards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.cards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    card.Name = Name;
                    card.DeckId = DeckId;
                    card.CardTypeId = CardTypeId;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.cards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.cards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public Card()
        {
        }

        internal Card(card card)
        {
            Id = card.Id;
            Name = card.Name;
            DeckId = card.DeckId;
            CardTypeId = card.CardTypeId;
            Deck = new Deck(card.deck);
            CardType = new CardType(card.cardtype);
        }
        internal card ToEntity()
        {
            var card = new card
            {
                Name = Name,
                DeckId = DeckId,
                CardTypeId = CardTypeId
            };

            return card;
        }
    }
}
