using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PcgApi.Models
{
    [DataContract]
    public class SubSkill
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Adjustment { get; set; }
        [DataMember]
        public int BaseSkillId { get; set; }

        internal SubSkill(DataAccess.Dto.SubSkill skill) : this(skill, true)
        {
        }

        internal SubSkill(DataAccess.Dto.SubSkill skill, bool deepObjects)
        {
            Id = skill.Id;
            Name = skill.Name;
            Adjustment = skill.Adjustment;
            BaseSkillId = skill.BaseSkillId;
        }
    }
}