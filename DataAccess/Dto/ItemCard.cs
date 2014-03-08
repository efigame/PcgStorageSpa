using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class ItemCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }

        public static ItemCard Get(int id)
        {
            ItemCard card = null;

            using (var data = new PcgStorageEntities())
            {
                var cardData = data.itemcards.SingleOrDefault(p => p.Id == id);
                if (cardData != null) card = new ItemCard(cardData);
            }

            return card;
        }
        public static List<ItemCard> All()
        {
            var cards = new List<ItemCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.itemcards.ToList();
                cards.AddRange(all.Select(a => new ItemCard(a)));
            }

            return cards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.itemcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var card = data.itemcards.SingleOrDefault(s => s.Id == Id);
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
                var card = data.itemcards.SingleOrDefault(s => s.Id == Id);
                if (card != null)
                {
                    data.itemcards.Remove(card);
                    data.SaveChanges();
                }
            }
        }

        public ItemCard()
        {
        }

        internal ItemCard(itemcard card)
        {
            Id = card.Id;
            Name = card.Name;
            AdventureDeckId = card.AdventureDeckId;
        }
        internal itemcard ToEntity()
        {
            var card = new itemcard
            {
                Name = Name,
                AdventureDeckId = AdventureDeckId
            };

            return card;
        }
    }
}
