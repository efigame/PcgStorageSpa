using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedAllyCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int AllyCardId { get; set; }
        public int Count { get; set; }

        public static RemovedAllyCard Get(int id)
        {
            RemovedAllyCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedallycards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedAllyCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedAllyCard> All(int partyId)
        {
            var removedCards = new List<RemovedAllyCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedallycards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedAllyCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedallycards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedallycards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.AllyCardId = AllyCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedallycards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedallycards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedAllyCard()
        {
        }

        internal RemovedAllyCard(removedallycard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            AllyCardId = removedCard.AllyCardId;
            Count = removedCard.Count;
        }
        internal removedallycard ToEntity()
        {
            var removedCard = new removedallycard
            {
                PartyId = PartyId,
                AllyCardId = AllyCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
