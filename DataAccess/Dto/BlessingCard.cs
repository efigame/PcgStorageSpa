using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class BlessingCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static BlessingCard Get(int id)
        {
            BlessingCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.blessingcards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new BlessingCard(cardData);
            }

            return card;
        }
        public static List<BlessingCard> All()
        {
            var cards = new List<BlessingCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.blessingcards.ToList();
                cards.AddRange(all.Select(a => new BlessingCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.blessingcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.blessingcards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.blessingcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.blessingcards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public BlessingCard()
        {
        }

        internal BlessingCard(blessingcard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal blessingcard ToEntity()
        {
            var card = new blessingcard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
