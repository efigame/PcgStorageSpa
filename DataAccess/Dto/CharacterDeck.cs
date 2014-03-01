using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class CharacterDeck
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public int PartyCharacterId { get; set; }
        public int Count { get; set; }
        public Card Card { get; set; }

        public static CharacterDeck Get(int id)
        {
            CharacterDeck characterDeck = null;

            using (var data = new PcgStorageEntities())
            {
                var characterDeckData = data.characterdecks.SingleOrDefault(p => p.Id == id);
                if (characterDeckData != null) characterDeck = new CharacterDeck(characterDeckData);
            }

            return characterDeck;
        }
        public static List<CharacterDeck> All(int characterCardId)
        {
            var characterDecks = new List<CharacterDeck>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characterdecks.Where(c => c.PartyCharacterId == characterCardId).ToList();
                characterDecks.AddRange(all.Select(a => new CharacterDeck(a)));
            }

            return characterDecks;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characterdecks.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterDeck = data.characterdecks.SingleOrDefault(s => s.Id == Id);
                if (characterDeck != null)
                {
                    characterDeck.PartyCharacterId = PartyCharacterId;
                    characterDeck.CardId = CardId;
                    characterDeck.Count = Count;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var characterDeck = data.characterdecks.SingleOrDefault(s => s.Id == Id);
                if (characterDeck != null)
                {
                    data.characterdecks.Remove(characterDeck);
                    data.SaveChanges();
                }
            }
        }

        public CharacterDeck()
        {
        }

        internal CharacterDeck(characterdeck characterDeck)
        {
            Id = characterDeck.Id;
            PartyCharacterId = characterDeck.PartyCharacterId;
            CardId = characterDeck.CardId;
            Count = characterDeck.Count;
            Card = new Card(characterDeck.card);
        }
        internal characterdeck ToEntity()
        {
            var characterDeck = new characterdeck
            {
                PartyCharacterId = PartyCharacterId,
                CardId = CardId,
                Count = Count
            };

            return characterDeck;
        }
    }
}
