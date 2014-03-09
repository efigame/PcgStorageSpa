using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedArmorCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int ArmorCardId { get; set; }
        public int Count { get; set; }

        public static RemovedArmorCard Get(int id)
        {
            RemovedArmorCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedarmorcards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedArmorCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedArmorCard> All(int partyId)
        {
            var removedCards = new List<RemovedArmorCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedarmorcards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedArmorCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedarmorcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedarmorcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.ArmorCardId = ArmorCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedarmorcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedarmorcards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedArmorCard()
        {
        }

        internal RemovedArmorCard(removedarmorcard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            ArmorCardId = removedCard.ArmorCardId;
            Count = removedCard.Count;
        }
        internal removedarmorcard ToEntity()
        {
            var removedCard = new removedarmorcard
            {
                PartyId = PartyId,
                ArmorCardId = ArmorCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
