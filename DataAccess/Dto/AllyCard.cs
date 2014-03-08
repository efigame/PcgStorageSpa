using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class AllyCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static AllyCard Get(int id)
        {
            AllyCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.allycards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new AllyCard(cardData);
            }

            return card;
        }
        public static List<AllyCard> All()
        {
            var cards = new List<AllyCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.allycards.ToList();
                cards.AddRange(all.Select(a => new AllyCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.allycards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.allycards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.allycards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.allycards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public AllyCard()
        {
        }

        internal AllyCard(allycard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal allycard ToEntity()
        {
            var card = new allycard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
