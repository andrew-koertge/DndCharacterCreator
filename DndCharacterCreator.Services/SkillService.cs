using DndCharacterCreator.Models.SkillModels;
using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Services
{
    public class SkillService
    {
        private readonly Guid _userId;

        public SkillService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSkill(SkillCreate model)
        {
            var entity =
                new Skill()
                {
                    SkillName = model.SkillName,
                    GovAttribute = model.GovAttribute
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Skills.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SkillListItem> GetSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Skills
                    .Select(
                        e => new SkillListItem
                        {
                            SkillId = e.SkillId,
                            SkillName = e.SkillName,
                            GovAttribute = e.GovAttribute
                        }
                        );
                return query.ToArray();
            }
        }

        public SkillDetail Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Skills
                     .Single(e => e.SkillId == id);

                return
                  new SkillDetail
                  {
                      SkillId = entity.SkillId,
                      SkillName = entity.SkillName,
                      GovAttribute = entity.GovAttribute
                  };
                    
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Skills
                    .Single(e => e.SkillId == id);

                ctx.Skills.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SkillEdit> Edit(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Skills
                    .Where(e => e.SkillId == id)
                    .Select(
                        e =>
                        new SkillEdit
                        {
                            SkillName = e.SkillName
                        }
                    );

                return query.ToArray();
            }
        }
    }
}
