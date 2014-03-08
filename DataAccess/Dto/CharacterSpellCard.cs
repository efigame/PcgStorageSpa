using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterSpellCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int SpellCardId { get; set; }
        public int Count { get; set; }

        public static CharacterSpellCard Get(int id)
        {
            CharacterSpellCard characterSpellCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterSpellCardData = data.characterspellcards.SingleOrDefault(p => p.Id == id);
                if (characterSpellCardData != null) characterSpellCard = new CharacterSpellCard(characterSpellCardData);
            }

            return characterSpellCard;
        }
        public static List<CharacterSpellCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterSpellCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterspellcards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterSpellCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterspellcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterSpellCard = data.characterspellcards.SingleOrDefault(s => s.Id == Id);
                if (characterSpellCard != null)
                {
                    characterSpellCard.CharacterId = CharacterId;
                    characterSpellCard.SpellCardId = SpellCardId;
                    characterSpellCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterSpellCard = data.characterspellcards.SingleOrDefault(s => s.Id == Id);
                if (characterSpellCard != null)
                {
                    data.characterspellcards.Remove(characterSpellCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterSpellCard()
        {
        }

        internal CharacterSpellCard(characterspellcard characterSpellCard)
        {
            Id = characterSpellCard.Id;
            CharacterId = characterSpellCard.CharacterId;
            SpellCardId = characterSpellCard.SpellCardId;
            Count = characterSpellCard.Count;
        }
        internal characterspellcard ToEntity()
        {
            var characterSpellCard = new characterspellcard
            {
                CharacterId = CharacterId,
                SpellCardId = SpellCardId,
                Count = Count
            };

            return characterSpellCard;
        }
    }
}
