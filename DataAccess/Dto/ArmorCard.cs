using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class ArmorCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static ArmorCard Get(int id)
        {
            ArmorCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.armorcards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new ArmorCard(cardData);
            }

            return card;
        }
        public static List<ArmorCard> All()
        {
            var cards = new List<ArmorCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.armorcards.ToList();
                cards.AddRange(all.Select(a => new ArmorCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.armorcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.armorcards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.armorcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.armorcards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public ArmorCard()
        {
        }

        internal ArmorCard(armorcard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal armorcard ToEntity()
        {
            var card = new armorcard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
