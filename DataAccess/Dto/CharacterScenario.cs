using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterScenario
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public int ScenarioId { get; set; }
        public int CharacterId { get; set; }

        public static CharacterScenario Get(int id)
        {
            CharacterScenario characterScenario = null;

            using (var data = new PcgStorageEntities())
            {
                var characterScenarioData = data.characterscenarios.SingleOrDefault(p => p.Id == id);
                if (characterScenarioData != null) characterScenario = new CharacterScenario(characterScenarioData);
            }

            return characterScenario;
        }
        public static List<CharacterScenario> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterScenario>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterscenarios.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterScenario(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterscenarios.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterScenario = data.characterscenarios.SingleOrDefault(s => s.Id == Id);
                if (characterScenario != null)
                {
                    characterScenario.Completed = Completed;
                    characterScenario.ScenarioId = ScenarioId;
                    characterScenario.CharacterId = CharacterId;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterScenario = data.characterscenarios.SingleOrDefault(s => s.Id == Id);
                if (characterScenario != null)
                {
                    data.characterscenarios.Remove(characterScenario);
                    data.SaveChanges();
                }
            }
        }

        public CharacterScenario()
        {
        }

        internal CharacterScenario(characterscenario characterScenario)
        {
            Id = characterScenario.Id;
            Completed = characterScenario.Completed;
            ScenarioId = characterScenario.ScenarioId;
            CharacterId = characterScenario.CharacterId;
        }
        internal characterscenario ToEntity()
        {
            var characterScenario = new characterscenario
            {
                Completed = Completed,
                ScenarioId = ScenarioId,
                CharacterId = CharacterId
            };

            return characterScenario;
        }
    }
}
