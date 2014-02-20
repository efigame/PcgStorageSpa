using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PartyId { get; set; }
        [DataMember]
        public int CharacterCardId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int LightArmors { get; set; }
        [DataMember]
        public int HeavyArmors { get; set; }
        [DataMember]
        public int Weapons { get; set; }
        [DataMember]
        public int WeaponCards { get; set; }
        [DataMember]
        public int PossibleWeaponCards { get; set; }
        [DataMember]
        public int? SelectedWeaponCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> WeaponCardsList { get; set; }
        [DataMember]
        public int SpellCards { get; set; }
        [DataMember]
        public int PossibleSpellCards { get; set; }
        [DataMember]
        public int? SelectedSpellCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> SpellCardsList { get; set; }
        [DataMember]
        public int ArmorCards { get; set; }
        [DataMember]
        public int PossibleArmorCards { get; set; }
        [DataMember]
        public int? SelectedArmorCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> ArmorCardsList { get; set; }
        [DataMember]
        public int ItemCards { get; set; }
        [DataMember]
        public int PossibleItemCards { get; set; }
        [DataMember]
        public int? SelectedItemCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> ItemCardsList { get; set; }
        [DataMember]
        public int AllyCards { get; set; }
        [DataMember]
        public int PossibleAllyCards { get; set; }
        [DataMember]
        public int? SelectedAllyCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> AllyCardsList { get; set; }
        [DataMember]
        public int BlessingCards { get; set; }
        [DataMember]
        public int PossibleBlessingCards { get; set; }
        [DataMember]
        public int? SelectedBlessingCards { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> BlessingCardsList { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> HandSizes { get; set; }
        [DataMember]
        public int HandSize { get; set; }
        [DataMember]
        public int PossibleHandSize { get; set; }
        [DataMember]
        public int? SelectedHandSize { get; set; }
        [DataMember]
        public string FavoredCardType { get; set; }

        [DataMember]
        public List<Skill> Skills { get; set; }
        [DataMember]
        public List<Power> Powers { get; set; }
        [DataMember]
        public List<SelectedCard> Deck { get; set; }
        [DataMember]
        public AvailableCards AvailableCards { get; set; }
        [DataMember]
        public SelectedCards SelectedCards { get; set; }

        public Character()
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter) : this(partyCharacter, true)
        {
        }
        internal Character(DataAccess.Dto.PartyCharacter partyCharacter, bool deepObjects)
        {
            Id = partyCharacter.Id;
            PartyId = partyCharacter.PartyId;
            CharacterCardId = partyCharacter.CharacterCardId;
            SelectedHandSize = partyCharacter.HandSize;
            SelectedWeaponCards = partyCharacter.WeaponCards;
            SelectedSpellCards = partyCharacter.SpellCards;
            SelectedArmorCards = partyCharacter.ArmorCards;
            SelectedItemCards = partyCharacter.ItemCards;
            SelectedAllyCards = partyCharacter.AllyCards;
            SelectedBlessingCards = partyCharacter.BlessingCards;
            HandSizes = new List<KeyValuePair<int, bool>>();
            WeaponCardsList = new List<KeyValuePair<int, bool>>();
            SpellCardsList = new List<KeyValuePair<int, bool>>();
            ArmorCardsList = new List<KeyValuePair<int, bool>>();
            ItemCardsList = new List<KeyValuePair<int, bool>>();
            AllyCardsList = new List<KeyValuePair<int, bool>>();
            BlessingCardsList = new List<KeyValuePair<int, bool>>();

            var lightArmor = partyCharacter.LightArmors;
            var heavyArmor = partyCharacter.HeavyArmors;
            var weapons = partyCharacter.Weapons;

            Skills = new List<Skill>();
            Powers = new List<Power>();
            Deck = new List<SelectedCard>();
            AvailableCards = new AvailableCards();
            SelectedCards = new SelectedCards(partyCharacter.Id);

            if (deepObjects)
            {
                var characterCard = DataAccess.Dto.CharacterCard.Get(partyCharacter.CharacterCardId);
                Name = characterCard.Name;
                HandSize = characterCard.BaseHandSize;
                LightArmors = (!lightArmor.HasValue || !(lightArmor.Value == 2)) ? characterCard.BaseLightArmors : lightArmor.Value;
                HeavyArmors = (!heavyArmor.HasValue || !(heavyArmor.Value == 2)) ? characterCard.BaseHeavyArmors : heavyArmor.Value;
                Weapons = (!weapons.HasValue || !(weapons.Value == 2)) ? characterCard.BaseWeapons : weapons.Value;
                WeaponCards = characterCard.BaseWeaponCards;
                SpellCards = characterCard.BaseSpellCards;
                ArmorCards = characterCard.BaseArmorCards;
                ItemCards = characterCard.BaseItemCards;
                AllyCards = characterCard.BaseAllyCards;
                BlessingCards = characterCard.BaseBlessingCards;
                PossibleHandSize = characterCard.PossibleHandSize;
                PossibleWeaponCards = characterCard.PossibleWeaponCards;
                PossibleSpellCards = characterCard.PossibleSpellCards;
                PossibleArmorCards = characterCard.PossibleArmorCards;
                PossibleItemCards = characterCard.PossibleItemCards;
                PossibleAllyCards = characterCard.PossibleAllyCards;
                PossibleBlessingCards = characterCard.PossibleBlessingCards;
                FavoredCardType = characterCard.FavoredCardType;

                HandSizes = GenerateCheckedList(HandSize + 1, PossibleHandSize, SelectedHandSize);
                WeaponCardsList = GenerateCheckedList(WeaponCards + 1, PossibleWeaponCards, SelectedWeaponCards);
                SpellCardsList = GenerateCheckedList(SpellCards + 1, PossibleSpellCards, SelectedSpellCards);
                ArmorCardsList = GenerateCheckedList(ArmorCards + 1, PossibleArmorCards, SelectedArmorCards);
                ItemCardsList = GenerateCheckedList(ItemCards + 1, PossibleItemCards, SelectedItemCards);
                AllyCardsList = GenerateCheckedList(AllyCards + 1, PossibleAllyCards, SelectedAllyCards);
                BlessingCardsList = GenerateCheckedList(BlessingCards + 1, PossibleBlessingCards, SelectedBlessingCards);

                var powers = DataAccess.Dto.Power.All(CharacterCardId);
                Powers.AddRange(powers.Select(p => new Power(p, Id)));

                var skills = DataAccess.Dto.Skill.All(CharacterCardId);
                Skills.AddRange(skills.Select(s => new Skill(s, Id)));

                var selectedCards = DataAccess.Dto.CharacterDeck.All(CharacterCardId);
                Deck.AddRange(selectedCards.Select(c => new SelectedCard(c, Id)));
            }
        }
        internal void Update()
        {
            KeyValuePair<int, bool>? handSizeFound = HandSizes.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (handSizeFound.HasValue) SelectedHandSize = handSizeFound.Value.Key;

            KeyValuePair<int, bool>? allyCardFound = AllyCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (allyCardFound.HasValue) SelectedAllyCards = allyCardFound.Value.Key;

            KeyValuePair<int, bool>? armorCardFound = ArmorCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (armorCardFound.HasValue) SelectedArmorCards = armorCardFound.Value.Key;

            KeyValuePair<int, bool>? blessingCardFound = BlessingCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (blessingCardFound.HasValue) SelectedBlessingCards = blessingCardFound.Value.Key;

            KeyValuePair<int, bool>? itemCardFound = ItemCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (itemCardFound.HasValue) SelectedItemCards = itemCardFound.Value.Key;

            KeyValuePair<int, bool>? spellCardFound = SpellCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (spellCardFound.HasValue) SelectedSpellCards = spellCardFound.Value.Key;

            KeyValuePair<int, bool>? weaponCardFound = WeaponCardsList.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (weaponCardFound.HasValue) SelectedWeaponCards = weaponCardFound.Value.Key;

            var partyCharacterData = DataAccess.Dto.PartyCharacter.Get(Id);
            partyCharacterData.LightArmors = LightArmors;
            partyCharacterData.HeavyArmors = HeavyArmors;
            partyCharacterData.Weapons = Weapons;
            partyCharacterData.HandSize = SelectedHandSize;
            partyCharacterData.AllyCards = SelectedAllyCards;
            partyCharacterData.ArmorCards = SelectedArmorCards;
            partyCharacterData.BlessingCards = SelectedBlessingCards;
            partyCharacterData.ItemCards = SelectedItemCards;
            partyCharacterData.SpellCards = SelectedSpellCards;
            partyCharacterData.WeaponCards = SelectedWeaponCards;

            partyCharacterData.Update();

            SelectedCards.Update(Id);
        }

        private List<KeyValuePair<int, bool>> GenerateCheckedList(int startValue, int maxValue, int? selectedValue)
        {
            var returnList = new List<KeyValuePair<int, bool>>();

            for (int i = startValue; i <= maxValue; i++)
            {
                if (selectedValue.HasValue && selectedValue.Value >= i)
                    returnList.Add(new KeyValuePair<int, bool>(i, true));
                else
                    returnList.Add(new KeyValuePair<int, bool>(i, false));
            }

            return returnList;
        }
    }
}