﻿using System;
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
        public int SpellCards { get; set; }
        [DataMember]
        public int PossibleSpellCards { get; set; }
        [DataMember]
        public int? SelectedSpellCards { get; set; }
        [DataMember]
        public int ArmorCards { get; set; }
        [DataMember]
        public int PossibleArmorCards { get; set; }
        [DataMember]
        public int? SelectedArmorCards { get; set; }
        [DataMember]
        public int ItemCards { get; set; }
        [DataMember]
        public int PossibleItemCards { get; set; }
        [DataMember]
        public int? SelectedItemCards { get; set; }
        [DataMember]
        public int AllyCards { get; set; }
        [DataMember]
        public int PossibleAllyCards { get; set; }
        [DataMember]
        public int? SelectedAllyCards { get; set; }
        [DataMember]
        public int BlessingCards { get; set; }
        [DataMember]
        public int PossibleBlessingCards { get; set; }
        [DataMember]
        public int? SelectedBlessingCards { get; set; }
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

            var lightArmor = partyCharacter.LightArmors;
            var heavyArmor = partyCharacter.HeavyArmors;
            var weapons = partyCharacter.Weapons;

            Skills = new List<Skill>();
            Powers = new List<Power>();

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

                for (int i = HandSize + 1; i <= PossibleHandSize; i++)
                {
                    if (SelectedHandSize >= i)
                        HandSizes.Add(new KeyValuePair<int, bool>(i, true));
                    else
                        HandSizes.Add(new KeyValuePair<int, bool>(i, false));
                }

                var powers = DataAccess.Dto.Power.All(CharacterCardId);
                Powers.AddRange(powers.Select(p => new Power(p, partyCharacter.Id)));

                var skills = DataAccess.Dto.Skill.All(CharacterCardId);
                Skills.AddRange(skills.Select(s => new Skill(s, Id)));
            }
        }
    }
}