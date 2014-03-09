using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedVillainCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int VillainCardId { get; set; }
        public int Count { get; set; }

        public static RemovedVillainCard Get(int id)
        {
            RemovedVillainCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedvillaincards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedVillainCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedVillainCard> All(int partyId)
        {
            var removedCards = new List<RemovedVillainCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedvillaincards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedVillainCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedvillaincards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedvillaincards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.VillainCardId = VillainCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedvillaincards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedvillaincards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedVillainCard()
        {
        }

        internal RemovedVillainCard(removedvillaincard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            VillainCardId = removedCard.VillainCardId;
            Count = removedCard.Count;
        }
        internal removedvillaincard ToEntity()
        {
            var removedCard = new removedvillaincard
            {
                PartyId = PartyId,
                VillainCardId = VillainCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
