using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Characters
    {
        [DataMember]
        public List<Character> Selected { get; set; }
        [DataMember]
        public List<KeyValuePair<CharacterCard, bool>> Possible { get; set; }

        public Characters()
        {
            Selected = new List<Character>();
            Possible = new List<KeyValuePair<CharacterCard, bool>>();
        }

        internal Characters(int partyId)
        {
            Selected = new List<Character>();
            Possible = new List<KeyValuePair<CharacterCard, bool>>();

            var characters = DataAccess.Dto.Character.All(partyId).ToList();
            Selected.AddRange(characters.Select(c => new Character(c)));

            var possibleCharacters = DataAccess.Dto.CharacterCard.All();
            foreach (var possibleCharacter in possibleCharacters)
            {
                Possible.Add(Selected.Select(c => c.CharacterCardId).Contains(possibleCharacter.Id)
                    ? new KeyValuePair<CharacterCard, bool>(new CharacterCard(possibleCharacter), true)
                    : new KeyValuePair<CharacterCard, bool>(new CharacterCard(possibleCharacter), false));
            }
        }

        internal void Update(int partyId)
        {
            var charactersToCreate = new List<int>();
            foreach (var valuePair in Possible.Where(p => p.Value))
            {
                if (!Selected.Select(c => c.CharacterCardId).Contains(valuePair.Key.Id))
                    charactersToCreate.Add(valuePair.Key.Id);
            }

            var charactersToDelete = new List<int>();
            foreach (var character in Selected)
            {
                if (!Possible.Where(p => p.Value).Select(p => p.Key.Id).Contains(character.CharacterCardId))
                    charactersToDelete.Add(character.Id);
            }

            foreach (var characterCardId in charactersToCreate)
            {
                var character = new DataAccess.Dto.Character
                {
                    PartyId = partyId,
                    CharacterCardId = characterCardId
                };

                character.Persist();
            }

            foreach (var characterId in charactersToDelete)
            {
                var character = DataAccess.Dto.Character.Get(characterId);
                character.Delete();
            }
        }
    }
}