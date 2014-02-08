using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class Skill
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Dice { get; set; }
        [DataMember]
        public List<KeyValuePair<int, bool>> Addons { get; set; }
        [DataMember]
        public int PossibleAddons { get; set; }
        [DataMember]
        public int SelectedAddons { get; set; }
        [DataMember]
        public List<SubSkill> SubSkills { get; set; }
        [DataMember]
        public int PartyCharacterId { get; set; }

        public Skill()
        {
        }

        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId) : this(skill, partyCharacterId, true)
        {
        }

        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId, bool deepObjects)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
            Addons = new List<KeyValuePair<int, bool>>();
            PartyCharacterId = partyCharacterId;

            PossibleAddons = skill.PossibleAddons;
            SubSkills = new List<SubSkill>();

            if (deepObjects)
            {
                var subSkills = DataAccess.Dto.SubSkill.All(Id);
                SubSkills.AddRange(subSkills.Select(s => new SubSkill(s)));

                var characterSkill = DataAccess.Dto.CharacterSkill.All(partyCharacterId).SingleOrDefault(c => c.SkillId == Id);
                if (characterSkill != null)
                    SelectedAddons = characterSkill.SelectedAdjustment;
                else
                    SelectedAddons = 0;

                for (int i = 1; i <= skill.PossibleAddons; i++)
                {
                    if (SelectedAddons >= i)
                        Addons.Add(new KeyValuePair<int, bool>(i, true));
                    else
                        Addons.Add(new KeyValuePair<int, bool>(i, false));
                }

            }
        }

        internal void SetSelectedAdjustment()
        {
            KeyValuePair<int, bool>? addonFound = Addons.Where(h => h.Value).OrderByDescending(h => h.Key).FirstOrDefault();
            if (addonFound.HasValue) SelectedAddons = addonFound.Value.Key;

            var characterSkill = DataAccess.Dto.CharacterSkill.All(PartyCharacterId).SingleOrDefault(c => c.SkillId == Id);
            if (characterSkill != null)
            {
                characterSkill.SelectedAdjustment = SelectedAddons;
                characterSkill.Update();
            }
            else
            {
                characterSkill = new DataAccess.Dto.CharacterSkill
                {
                    PartyCharacterId = PartyCharacterId,
                    SkillId = Id,
                    SelectedAdjustment = SelectedAddons
                };

                characterSkill.Persist();
            }
        }
    }
}