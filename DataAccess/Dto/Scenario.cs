using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class Scenario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int AdventureDeckId { get; set; }

        public static Scenario Get(int id)
        {
            Scenario scenario = null;

            using (var data = new PcgStorageEntities())
            {
                var scenarioData = data.scenarios.SingleOrDefault(p => p.Id == id);
                if (scenarioData != null) scenario = new Scenario(scenarioData);
            }

            return scenario;
        }
        public static List<Scenario> All()
        {
            var scenarios = new List<Scenario>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.scenarios.ToList();
                scenarios.AddRange(all.Select(a => new Scenario(a)));
            }

            return scenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.scenarios.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var scenario = data.scenarios.SingleOrDefault(s => s.Id == Id);
                if (scenario != null)
                {
                    scenario.Name = Name;
                    scenario.Index = Index;
                    scenario.AdventureDeckId = AdventureDeckId;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var scenario = data.scenarios.SingleOrDefault(s => s.Id == Id);
                if (scenario != null)
                {
                    data.scenarios.Remove(scenario);
                    data.SaveChanges();
                }
            }
        }

        public Scenario()
        {
        }

        internal Scenario(scenario scenario)
        {
            Id = scenario.Id;
            Name = scenario.Name;
            Index = scenario.Index;
            AdventureDeckId = scenario.AdventureDeckId;
        }
        internal scenario ToEntity()
        {
            var scenario = new scenario
            {
                Name = Name,
                Index = Index,
                AdventureDeckId = AdventureDeckId
            };

            return scenario;
        }
    }
}
