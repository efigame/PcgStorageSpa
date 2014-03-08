using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterBlessingCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int BlessingCardId { get; set; }
        public int Count { get; set; }

        public static CharacterBlessingCard Get(int id)
        {
            CharacterBlessingCard characterBlessingCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterBlessingCardData = data.characterblessingcards.SingleOrDefault(p => p.Id == id);
                if (characterBlessingCardData != null) characterBlessingCard = new CharacterBlessingCard(characterBlessingCardData);
            }

            return characterBlessingCard;
        }
        public static List<CharacterBlessingCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterBlessingCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterblessingcards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterBlessingCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterblessingcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterBlessingCard = data.characterblessingcards.SingleOrDefault(s => s.Id == Id);
                if (characterBlessingCard != null)
                {
                    characterBlessingCard.CharacterId = CharacterId;
                    characterBlessingCard.BlessingCardId = BlessingCardId;
                    characterBlessingCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterBlessingCard = data.characterblessingcards.SingleOrDefault(s => s.Id == Id);
                if (characterBlessingCard != null)
                {
                    data.characterblessingcards.Remove(characterBlessingCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterBlessingCard()
        {
        }

        internal CharacterBlessingCard(characterblessingcard characterBlessingCard)
        {
            Id = characterBlessingCard.Id;
            CharacterId = characterBlessingCard.CharacterId;
            BlessingCardId = characterBlessingCard.BlessingCardId;
            Count = characterBlessingCard.Count;
        }
        internal characterblessingcard ToEntity()
        {
            var characterBlessingCard = new characterblessingcard
            {
                CharacterId = CharacterId,
                BlessingCardId = BlessingCardId,
                Count = Count
            };

            return characterBlessingCard;
        }
    }
}
