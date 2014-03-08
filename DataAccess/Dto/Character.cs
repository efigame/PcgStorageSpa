using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class Character
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int CharacterCardId { get; set; }
        public int? LightArmors { get; set; }
        public int? HeavyArmors { get; set; }
        public int? Weapons { get; set; }
        public int? WeaponCards { get; set; }
        public int? SpellCards { get; set; }
        public int? ArmorCards { get; set; }
        public int? ItemCards { get; set; }
        public int? AllyCards { get; set; }
        public int? BlessingCards { get; set; }
        public int? HandSize { get; set; }
        public DateTime? DeletedDate { get; set; }

        public static Character Get(int id)
        {
            Character character = null;

            using (var data = new PcgStorageEntities())
            {
                var characterData = data.characters.SingleOrDefault(p => p.Id == id);
                if (characterData != null) character = new Character(characterData);
            }

            return character;
        }
        public static List<Character> All(int partyId)
        {
            var characters = new List<Character>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.characters.Where(p => p.PartyId == partyId && !p.DeletedDate.HasValue).ToList();
                characters.AddRange(all.Select(a => new Character(a)));
            }

            return characters;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.characters.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var character = data.characters.SingleOrDefault(p => p.Id == Id);
                if (character != null)
                {
                    character.CharacterCardId = CharacterCardId;
                    character.PartyId = PartyId;
                    character.LightArmors = LightArmors;
                    character.HeavyArmors = HeavyArmors;
                    character.Weapons = Weapons;
                    character.WeaponCards = WeaponCards;
                    character.SpellCards = SpellCards;
                    character.ArmorCards = ArmorCards;
                    character.ItemCards = ItemCards;
                    character.AllyCards = AllyCards;
                    character.BlessingCards = BlessingCards;
                    character.HandSize = HandSize;
                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var character = data.characters.SingleOrDefault(p => p.Id == Id);
                if (character != null)
                {
                    character.DeletedDate = DateTime.Now;
                    data.SaveChanges();
                }
            }
        }

        public Character()
        {
        }

        internal Character(character character)
        {
            Id = character.Id;
            PartyId = character.PartyId;
            CharacterCardId = character.CharacterCardId;
            LightArmors = character.LightArmors;
            HeavyArmors = character.HeavyArmors;
            Weapons = character.Weapons;
            WeaponCards = character.WeaponCards;
            SpellCards = character.SpellCards;
            ArmorCards = character.ArmorCards;
            ItemCards = character.ItemCards;
            AllyCards = character.AllyCards;
            BlessingCards = character.BlessingCards;
            HandSize = character.HandSize;
            DeletedDate = character.DeletedDate;
        }
        internal character ToEntity()
        {
            var character = new character
            {
                PartyId = PartyId,
                CharacterCardId = CharacterCardId,
                LightArmors = LightArmors,
                HeavyArmors = HeavyArmors,
                Weapons = Weapons,
                WeaponCards = WeaponCards,
                SpellCards = SpellCards,
                ArmorCards = ArmorCards,
                ItemCards = ItemCards,
                AllyCards = AllyCards,
                BlessingCards = BlessingCards,
                HandSize = HandSize,
                DeletedDate = DeletedDate
            };

            return character;
        }
    }
}
