using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class BarrierCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static BarrierCard Get(int id)
        {
            BarrierCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.barriercards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new BarrierCard(cardData);
            }

            return card;
        }
        public static List<BarrierCard> All()
        {
            var cards = new List<BarrierCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.barriercards.ToList();
                cards.AddRange(all.Select(a => new BarrierCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.barriercards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.barriercards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.barriercards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.barriercards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public BarrierCard()
        {
        }

        internal BarrierCard(barriercard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal barriercard ToEntity()
        {
            var card = new barriercard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
