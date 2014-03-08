using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterArmorCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int ArmorCardId { get; set; }
        public int Count { get; set; }

        public static CharacterArmorCard Get(int id)
        {
            CharacterArmorCard characterArmorCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterArmorCardData = data.characterarmorcards.SingleOrDefault(p => p.Id == id);
                if (characterArmorCardData != null) characterArmorCard = new CharacterArmorCard(characterArmorCardData);
            }

            return characterArmorCard;
        }
        public static List<CharacterArmorCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterArmorCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterarmorcards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterArmorCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterarmorcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterArmorCard = data.characterarmorcards.SingleOrDefault(s => s.Id == Id);
                if (characterArmorCard != null)
                {
                    characterArmorCard.CharacterId = CharacterId;
                    characterArmorCard.ArmorCardId = ArmorCardId;
                    characterArmorCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterArmorCard = data.characterarmorcards.SingleOrDefault(s => s.Id == Id);
                if (characterArmorCard != null)
                {
                    data.characterarmorcards.Remove(characterArmorCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterArmorCard()
        {
        }

        internal CharacterArmorCard(characterarmorcard characterArmorCard)
        {
            Id = characterArmorCard.Id;
            CharacterId = characterArmorCard.CharacterId;
            ArmorCardId = characterArmorCard.ArmorCardId;
            Count = characterArmorCard.Count;
        }
        internal characterarmorcard ToEntity()
        {
            var characterArmorCard = new characterarmorcard
            {
                CharacterId = CharacterId,
                ArmorCardId = ArmorCardId,
                Count = Count
            };

            return characterArmorCard;
        }
    }
}
