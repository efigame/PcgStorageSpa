using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class AdventurePath
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static AdventurePath Get(int id)
        {
            AdventurePath adventurePath = null;

            using (var data = new PcgStorageEntities())
            {
                var adventureData = data.adventurepaths.SingleOrDefault(p => p.Id == id);
                if (adventureData != null) adventurePath = new AdventurePath(adventureData);
            }

            return adventurePath;
        }
        public static List<AdventurePath> All()
        {
            var adventurePaths = new List<AdventurePath>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.adventurepaths.ToList();
                adventurePaths.AddRange(all.Select(a => new AdventurePath(a)));
            }

            return adventurePaths;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.adventurepaths.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventurePath = data.adventurepaths.SingleOrDefault(s => s.Id == Id);
                if (adventurePath != null)
                {
                    adventurePath.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var adventurePath = data.adventurepaths.SingleOrDefault(s => s.Id == Id);
                if (adventurePath != null)
                {
                    data.adventurepaths.Remove(adventurePath);
                    data.SaveChanges();
                }
            }
        }

        public AdventurePath()
        {
        }

        internal AdventurePath(adventurepath adventurePath)
        {
            Id = adventurePath.Id;
            Name = adventurePath.Name;
        }
        internal adventurepath ToEntity()
        {
            var adventurePath = new adventurepath
            {
                Name = Name
            };

            return adventurePath;
        }
    }
}
