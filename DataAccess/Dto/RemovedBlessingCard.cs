using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedBlessingCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int BlessingCardId { get; set; }
        public int Count { get; set; }

        public static RemovedBlessingCard Get(int id)
        {
            RemovedBlessingCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedblessingcards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedBlessingCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedBlessingCard> All(int partyId)
        {
            var removedCards = new List<RemovedBlessingCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedblessingcards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedBlessingCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedblessingcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedblessingcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.BlessingCardId = BlessingCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedblessingcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedblessingcards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedBlessingCard()
        {
        }

        internal RemovedBlessingCard(removedblessingcard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            BlessingCardId = removedCard.BlessingCardId;
            Count = removedCard.Count;
        }
        internal removedblessingcard ToEntity()
        {
            var removedCard = new removedblessingcard
            {
                PartyId = PartyId,
                BlessingCardId = BlessingCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
