using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedMonsterCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int MonsterCardId { get; set; }
        public int Count { get; set; }

        public static RemovedMonsterCard Get(int id)
        {
            RemovedMonsterCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedmonstercards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedMonsterCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedMonsterCard> All(int partyId)
        {
            var removedCards = new List<RemovedMonsterCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedmonstercards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedMonsterCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedmonstercards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedmonstercards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.MonsterCardId = MonsterCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedmonstercards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedmonstercards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedMonsterCard()
        {
        }

        internal RemovedMonsterCard(removedmonstercard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            MonsterCardId = removedCard.MonsterCardId;
            Count = removedCard.Count;
        }
        internal removedmonstercard ToEntity()
        {
            var removedCard = new removedmonstercard
            {
                PartyId = PartyId,
                MonsterCardId = MonsterCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
