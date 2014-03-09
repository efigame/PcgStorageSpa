using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedItemCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ItemCardId { get; set; }
        public int Count { get; set; }

        public static RemovedItemCard Get(int id)
        {
            RemovedItemCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removeditemcards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedItemCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedItemCard> All(int partyId)
        {
            var removedCards = new List<RemovedItemCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removeditemcards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedItemCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removeditemcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removeditemcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.ItemCardId = ItemCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removeditemcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removeditemcards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedItemCard()
        {
        }

        internal RemovedItemCard(removeditemcard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            ItemCardId = removedCard.ItemCardId;
            Count = removedCard.Count;
        }
        internal removeditemcard ToEntity()
        {
            var removedCard = new removeditemcard
            {
                PartyId = PartyId,
                ItemCardId = ItemCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
