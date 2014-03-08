using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class WeaponCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static WeaponCard Get(int id)
        {
            WeaponCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.weaponcards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new WeaponCard(cardData);
            }

            return card;
        }
        public static List<WeaponCard> All()
        {
            var cards = new List<WeaponCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.weaponcards.ToList();
                cards.AddRange(all.Select(a => new WeaponCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.weaponcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.weaponcards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.weaponcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.weaponcards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public WeaponCard()
        {
        }

        internal WeaponCard(weaponcard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal weaponcard ToEntity()
        {
            var card = new weaponcard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
