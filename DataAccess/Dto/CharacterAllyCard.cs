using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterAllyCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int AllyCardId { get; set; }
        public int Count { get; set; }

        public static CharacterAllyCard Get(int id)
        {
            CharacterAllyCard characterAllyCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterAllyCardData = data.characterallycards.SingleOrDefault(p => p.Id == id);
                if (characterAllyCardData != null) characterAllyCard = new CharacterAllyCard(characterAllyCardData);
            }

            return characterAllyCard;
        }
        public static List<CharacterAllyCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterAllyCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterallycards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterAllyCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterallycards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterAllyCard = data.characterallycards.SingleOrDefault(s => s.Id == Id);
                if (characterAllyCard != null)
                {
                    characterAllyCard.CharacterId = CharacterId;
                    characterAllyCard.AllyCardId = AllyCardId;
                    characterAllyCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterAllyCard = data.characterallycards.SingleOrDefault(s => s.Id == Id);
                if (characterAllyCard != null)
                {
                    data.characterallycards.Remove(characterAllyCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterAllyCard()
        {
        }

        internal CharacterAllyCard(characterallycard characterAllyCard)
        {
            Id = characterAllyCard.Id;
            CharacterId = characterAllyCard.CharacterId;
            AllyCardId = characterAllyCard.AllyCardId;
            Count = characterAllyCard.Count;
        }
        internal characterallycard ToEntity()
        {
            var characterAllyCard = new characterallycard
            {
                CharacterId = CharacterId,
                AllyCardId = AllyCardId,
                Count = Count
            };

            return characterAllyCard;
        }
    }
}
