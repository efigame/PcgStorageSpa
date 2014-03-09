using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedBarrierCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int BarrierCardId { get; set; }
        public int Count { get; set; }

        public static RemovedBarrierCard Get(int id)
        {
            RemovedBarrierCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedbarriercards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedBarrierCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedBarrierCard> All(int partyId)
        {
            var removedCards = new List<RemovedBarrierCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedbarriercards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedBarrierCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedbarriercards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedbarriercards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.BarrierCardId = BarrierCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedbarriercards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedbarriercards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedBarrierCard()
        {
        }

        internal RemovedBarrierCard(removedbarriercard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            BarrierCardId = removedCard.BarrierCardId;
            Count = removedCard.Count;
        }
        internal removedbarriercard ToEntity()
        {
            var removedCard = new removedbarriercard
            {
                PartyId = PartyId,
                BarrierCardId = BarrierCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
