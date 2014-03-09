using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class VillainCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static VillainCard Get(int id)
        {
            VillainCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.villaincards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new VillainCard(cardData);
            }

            return card;
        }
        public static List<VillainCard> All()
        {
            var cards = new List<VillainCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.villaincards.ToList();
                cards.AddRange(all.Select(a => new VillainCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.villaincards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.villaincards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.villaincards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.villaincards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public VillainCard()
        {
        }

        internal VillainCard(villaincard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal villaincard ToEntity()
        {
            var card = new villaincard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
