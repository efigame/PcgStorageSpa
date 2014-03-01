using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PcgApi.Models
{
    [DataContract]
    public class Party
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public List<Character> Characters { get; set; }
        [DataMember]
        public List<KeyValuePair<CharacterCard, bool>> PossibleCharacters { get; set; }

        public Party()
        {
        }
        internal Party(DataAccess.Dto.Party party) : this(party, true)
        {
        }
        internal Party(DataAccess.Dto.Party party, bool deepObjects)
        {
            Id = party.Id;
            Name = party.Name;
            UserId = party.PcgUserId;
            Characters = new List<Character>();
            PossibleCharacters = new List<KeyValuePair<CharacterCard, bool>>();

            if (deepObjects)
            {
                var characters = DataAccess.Dto.PartyCharacter.All(Id).ToList();
                Characters.AddRange(characters.Select(c => new Character(c)));

                var possibleCharacters = DataAccess.Dto.CharacterCard.All();
                foreach (var possibleCharacter in possibleCharacters)
                {
                    PossibleCharacters.Add(Characters.Select(c => c.CharacterCardId).Contains(possibleCharacter.Id)
                        ? new KeyValuePair<CharacterCard, bool>(new CharacterCard(possibleCharacter), true)
                        : new KeyValuePair<CharacterCard, bool>(new CharacterCard(possibleCharacter), false));
                }
            }
        }

        internal void Update()
        {
            var party = DataAccess.Dto.Party.Get(Id);
            party.Name = Name;
            party.Update();

            var charactersToCreate = new List<int>();
            foreach (var valuePair in PossibleCharacters.Where(p => p.Value))
            {
                if (!Characters.Select(c => c.CharacterCardId).Contains(valuePair.Key.Id))
                    charactersToCreate.Add(valuePair.Key.Id);
            }

            var charactersToDelete = new List<int>();
            foreach (var character in Characters)
            {
                if (!PossibleCharacters.Where(p => p.Value).Select(p => p.Key.Id).Contains(character.CharacterCardId))
                    charactersToDelete.Add(character.Id);
            }

            foreach (var characterCardId in charactersToCreate)
            {
                var character = new DataAccess.Dto.PartyCharacter
                    {
                         PartyId = Id,
                         CharacterCardId = characterCardId
                    };

                character.Persist();
            }

            foreach (var characterId in charactersToDelete)
            {
                var character = DataAccess.Dto.PartyCharacter.Get(characterId);
                character.Delete();
            }
        }
    }
}