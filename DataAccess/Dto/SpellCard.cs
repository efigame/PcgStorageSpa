using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class SpellCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static SpellCard Get(int id)
        {
            SpellCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.spellcards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new SpellCard(cardData);
            }

            return card;
        }
        public static List<SpellCard> All()
        {
            var cards = new List<SpellCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.spellcards.ToList();
                cards.AddRange(all.Select(a => new SpellCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.spellcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.spellcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    card.Name = Name;
                    card.AdventureDeckId = AdventureDeckId;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.spellcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.spellcards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public SpellCard()
        {
        }

        internal SpellCard(spellcard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal spellcard ToEntity()
        {
            var card = new spellcard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
