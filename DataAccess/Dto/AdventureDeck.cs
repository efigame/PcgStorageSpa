using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class AdventureDeck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventurePathId { get; set; }
        public AdventurePath Adventure { get; set; }

        public static AdventureDeck Get(int id)
        {
            AdventureDeck adventureDeck = null;

            using (var data = new PcgStorageEntities())
            {
                var adventureDeckData = data.adventuredecks.SingleOrDefault(p => p.Id == id);
                if (adventureDeckData != null) adventureDeck = new AdventureDeck(adventureDeckData);
            }

            return adventureDeck;
        }
        public static List<AdventureDeck> All()
        {
            var adventureDecks = new List<AdventureDeck>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.adventuredecks.ToList();
                adventureDecks.AddRange(all.Select(a => new AdventureDeck(a)));
            }

            return adventureDecks;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.adventuredecks.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventureDeck = data.adventuredecks.SingleOrDefault(s => s.Id == Id);
                if (adventureDeck != null)
                {
                    adventureDeck.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventureDeck = data.adventuredecks.SingleOrDefault(s => s.Id == Id);
                if (adventureDeck != null)
                {
                    data.adventuredecks.Remove(adventureDeck);
                    data.SaveChanges();
                }
            }
        }

        public AdventureDeck()
        {
        }

        internal AdventureDeck(adventuredeck adventureDeck)
        {
            Id = adventureDeck.Id;
            Name = adventureDeck.Name;
            AdventurePathId = adventureDeck.AdventurePathId;
            Adventure = new AdventurePath(adventureDeck.adventurepath);
        }
        internal adventuredeck ToEntity()
        {
            var adventureDeck = new adventuredeck
            {
                Name = Name,
                AdventurePathId = AdventurePathId
            };

            return adventureDeck;
        }
    }
}
