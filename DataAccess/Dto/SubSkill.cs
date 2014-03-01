using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class SubSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseSkillId { get; set; }
        public int Adjustment { get; set; }

        public static SubSkill Get(int id)
        {
            SubSkill skill = null;

            using (var data = new PcgStorageEntities())
            {
                var subSkill = data.subskills.SingleOrDefault(p => p.Id == id);
                if (subSkill != null) skill = new SubSkill(subSkill);
            }

            return skill;
        }
        public static List<SubSkill> All(int baseSkillId)
        {
            var skills = new List<SubSkill>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.subskills.Where(s => s.BaseSkillId == baseSkillId).ToList();
                skills.AddRange(all.Select(a => new SubSkill(a)));
            }

            return skills;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var entity = ToEntity();
                data.subskills.Add(entity);
                data.SaveChanges();

                Id = entity.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var skill = data.subskills.SingleOrDefault(s => s.Id == Id);
                if (skill != null)
                {
                    skill.Adjustment = Adjustment;
                    skill.Name = Name;

                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var skill = data.subskills.SingleOrDefault(s => s.Id == Id);
                if (skill != null)
                {
                    data.subskills.Remove(skill);
                    data.SaveChanges();
                }
            }
        }

        public SubSkill()
        {
        }

        internal SubSkill(subskill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Adjustment = skill.Adjustment;
            BaseSkillId = skill.BaseSkillId;
        }
        internal subskill ToEntity()
        {
            var skill = new subskill
            {
                Adjustment = Adjustment,
                BaseSkillId = BaseSkillId,
                Name = Name
            };

            return skill;
        }


        
    }
}
