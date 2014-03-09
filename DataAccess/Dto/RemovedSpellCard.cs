using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class RemovedSpellCard
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int SpellCardId { get; set; }
        public int Count { get; set; }

        public static RemovedSpellCard Get(int id)
        {
            RemovedSpellCard removedCard = null;

            using (var data = new PcgStorageEntities())
            {
                var removedCardData = data.removedspellcards.SingleOrDefault(p => p.Id == id);
                if (removedCardData != null) removedCard = new RemovedSpellCard(removedCardData);
            }

            return removedCard;
        }
        public static List<RemovedSpellCard> All(int partyId)
        {
            var removedCards = new List<RemovedSpellCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.removedspellcards.Where(c => c.PartyId == partyId).ToList();
                removedCards.AddRange(all.Select(a => new RemovedSpellCard(a)));
            }

            return removedCards;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.removedspellcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedspellcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    removedCard.PartyId = PartyId;
                    removedCard.SpellCardId = SpellCardId;
                    removedCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var removedCard = data.removedspellcards.SingleOrDefault(s => s.Id == Id);
                if (removedCard != null)
                {
                    data.removedspellcards.Remove(removedCard);
                    data.SaveChanges();
                }
            }
        }

        public RemovedSpellCard()
        {
        }

        internal RemovedSpellCard(removedspellcard removedCard)
        {
            Id = removedCard.Id;
            PartyId = removedCard.PartyId;
            SpellCardId = removedCard.SpellCardId;
            Count = removedCard.Count;
        }
        internal removedspellcard ToEntity()
        {
            var removedCard = new removedspellcard
            {
                PartyId = PartyId,
                SpellCardId = SpellCardId,
                Count = Count
            };

            return removedCard;
        }
    }
}
