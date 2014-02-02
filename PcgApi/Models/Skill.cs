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
        public int PossibleAddons { get; set; }
        [DataMember]
        public int SelectedAddons { get; set; }
        [DataMember]
        public List<SubSkill> SubSkills { get; set; }

        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId) : this(skill, partyCharacterId, true)
        {
        }

        internal Skill(DataAccess.Dto.Skill skill, int partyCharacterId, bool deepObjects)
        {
            Id = skill.Id;
            Name = skill.Name;
            Dice = skill.Dice;
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
            }
        }
    }
}