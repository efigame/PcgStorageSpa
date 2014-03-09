using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedHenchmenCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int HenchmenCardId { get; set; }
        public int Count { get; set; }

        public static RemovedHenchmenCard Get(int id)
        {
            RemovedHenchmenCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedhenchmencards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedHenchmenCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedHenchmenCard> All(int partyId)
        {
            var removedCards = new List<RemovedHenchmenCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedhenchmencards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedHenchmenCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedhenchmencards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedhenchmencards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.HenchmenCardId = HenchmenCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedhenchmencards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedhenchmencards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedHenchmenCard()
        {
        }

        internal RemovedHenchmenCard(removedhenchmencard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            HenchmenCardId = removedCard.HenchmenCardId;
            Count = removedCard.Count;
        }
        internal removedhenchmencard ToEntity()
        {
            var removedCard = new removedhenchmencard
            {
                PartyId = PartyId,
                HenchmenCardId = HenchmenCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
