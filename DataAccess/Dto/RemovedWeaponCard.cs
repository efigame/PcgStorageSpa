using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedWeaponCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int WeaponCardId { get; set; }
        public int Count { get; set; }

        public static RemovedWeaponCard Get(int id)
        {
            RemovedWeaponCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedweaponcards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedWeaponCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedWeaponCard> All(int partyId)
        {
            var removedCards = new List<RemovedWeaponCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedweaponcards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedWeaponCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedweaponcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedweaponcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.WeaponCardId = WeaponCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedweaponcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedweaponcards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedWeaponCard()
        {
        }

        internal RemovedWeaponCard(removedweaponcard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            WeaponCardId = removedCard.WeaponCardId;
            Count = removedCard.Count;
        }
        internal removedweaponcard ToEntity()
        {
            var removedCard = new removedweaponcard
            {
                PartyId = PartyId,
                WeaponCardId = WeaponCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
