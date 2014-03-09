using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class MonsterCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static MonsterCard Get(int id)
        {
            MonsterCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.monstercards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new MonsterCard(cardData);
            }

            return card;
        }
        public static List<MonsterCard> All()
        {
            var cards = new List<MonsterCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.monstercards.ToList();
                cards.AddRange(all.Select(a => new MonsterCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.monstercards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.monstercards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.monstercards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.monstercards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public MonsterCard()
        {
        }

        internal MonsterCard(monstercard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal monstercard ToEntity()
        {
            var card = new monstercard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
