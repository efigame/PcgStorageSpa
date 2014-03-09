using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class HenchmenCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static HenchmenCard Get(int id)
        {
            HenchmenCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.henchmencards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new HenchmenCard(cardData);
            }

            return card;
        }
        public static List<HenchmenCard> All()
        {
            var cards = new List<HenchmenCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.henchmencards.ToList();
                cards.AddRange(all.Select(a => new HenchmenCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.henchmencards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.henchmencards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.henchmencards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.henchmencards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public HenchmenCard()
        {
        }

        internal HenchmenCard(henchmencard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal henchmencard ToEntity()
        {
            var card = new henchmencard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
