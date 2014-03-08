using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterWeaponCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int WeaponCardId { get; set; }
        public int Count { get; set; }

        public static CharacterWeaponCard Get(int id)
        {
            CharacterWeaponCard characterWeaponCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterWeaponCardData = data.characterweaponcards.SingleOrDefault(p => p.Id == id);
                if (characterWeaponCardData != null) characterWeaponCard = new CharacterWeaponCard(characterWeaponCardData);
            }

            return characterWeaponCard;
        }
        public static List<CharacterWeaponCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterWeaponCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterweaponcards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterWeaponCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterweaponcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterWeaponCard = data.characterweaponcards.SingleOrDefault(s => s.Id == Id);
                if (characterWeaponCard != null)
                {
                    characterWeaponCard.CharacterId = CharacterId;
                    characterWeaponCard.WeaponCardId = WeaponCardId;
                    characterWeaponCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterWeaponCard = data.characterweaponcards.SingleOrDefault(s => s.Id == Id);
                if (characterWeaponCard != null)
                {
                    data.characterweaponcards.Remove(characterWeaponCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterWeaponCard()
        {
        }

        internal CharacterWeaponCard(characterweaponcard characterWeaponCard)
        {
            Id = characterWeaponCard.Id;
            CharacterId = characterWeaponCard.CharacterId;
            WeaponCardId = characterWeaponCard.WeaponCardId;
            Count = characterWeaponCard.Count;
        }
        internal characterweaponcard ToEntity()
        {
            var characterWeaponCard = new characterweaponcard
            {
                CharacterId = CharacterId,
                WeaponCardId = WeaponCardId,
                Count = Count
            };

            return characterWeaponCard;
        }
    }
}
