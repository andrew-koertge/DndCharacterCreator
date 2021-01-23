using DndCharacterCreator.Models.SpellModels;
using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Services
{
    public class SpellService
    {
        private readonly Guid _userId;
        public SpellService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpell(SpellCreate model)
        {
            var entity =
                new Spell()
                {
                    Level = model.Level,
                    SpellName = model.SpellName,
                    CastTime = model.CastTime,
                    CastDuration = model.CastDuration,
                    Range = model.Range,
                    DamageType = model.DamageType,
                    School = model.School,
                    Damage = model.Damage,
                    Components = model.Components
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spells.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpellListItem> GetSpells()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Spells
                    .Select(
                        e => new SpellListItem
                        {
                            SpellId = e.SpellId,
                            Level = e.Level,
                            SpellName = e.SpellName,
                            CastTime = e.CastTime,
                            CastDuration = e.CastDuration,
                            Range = e.Range,
                            DamageType = e.DamageType
                        }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<SpellDetail> Details(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Spells
                    .Where(e => e.SpellId == id)
                    .Select(
                      e =>
                      new SpellDetail
                      {
                          SpellId = e.SpellId,
                          Level = e.Level,
                          SpellName = e.SpellName,
                          CastTime = e.CastTime,
                          CastDuration = e.CastDuration,
                          Range = e.Range,
                          DamageType = e.DamageType,
                          School = e.School,
                          Components = e.Components,
                          Damage = e.Damage
                      }
                    );
                return query.ToArray();
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Spells
                    .Single(e => e.SpellId == id);

                ctx.Spells.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpellEdit> Edit(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Spells
                    .Where(e => e.SpellId == id)
                    .Select(
                        e =>
                        new SpellEdit
                        {
                            SpellName = e.SpellName,
                            CastTime = e.CastTime,
                            CastDuration = e.CastDuration,
                            Damage = e.Damage,
                            Range = e.Range
                        }
                    );

                return query.ToArray();
            }
        }
    }
}
