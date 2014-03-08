using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterItemCard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int ItemCardId { get; set; }
        public int Count { get; set; }

        public static CharacterItemCard Get(int id)
        {
            CharacterItemCard characterItemCard = null;

            using (var data = new PcgStorageEntities())
            {
                var characterItemCardData = data.characteritemcards.SingleOrDefault(p => p.Id == id);
                if (characterItemCardData != null) characterItemCard = new CharacterItemCard(characterItemCardData);
            }

            return characterItemCard;
        }
        public static List<CharacterItemCard> All(int characterCardId)
        {
            var characterScenarios = new List<CharacterItemCard>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characteritemcards.Where(c => c.CharacterId == characterCardId).ToList();
                characterScenarios.AddRange(all.Select(a => new CharacterItemCard(a)));
            }

            return characterScenarios;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characteritemcards.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterItemCard = data.characteritemcards.SingleOrDefault(s => s.Id == Id);
                if (characterItemCard != null)
                {
                    characterItemCard.CharacterId = CharacterId;
                    characterItemCard.ItemCardId = ItemCardId;
                    characterItemCard.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterItemCard = data.characteritemcards.SingleOrDefault(s => s.Id == Id);
                if (characterItemCard != null)
                {
                    data.characteritemcards.Remove(characterItemCard);
                    data.SaveChanges();
                }
            }
        }

        public CharacterItemCard()
        {
        }

        internal CharacterItemCard(characteritemcard characterItemCard)
        {
            Id = characterItemCard.Id;
            CharacterId = characterItemCard.CharacterId;
            ItemCardId = characterItemCard.ItemCardId;
            Count = characterItemCard.Count;
        }
        internal characteritemcard ToEntity()
        {
            var characterItemCard = new characteritemcard
            {
                CharacterId = CharacterId,
                ItemCardId = ItemCardId,
                Count = Count
            };

            return characterItemCard;
        }
    }
}
