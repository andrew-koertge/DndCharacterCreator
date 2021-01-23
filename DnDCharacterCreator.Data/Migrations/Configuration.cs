namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DnDCharacterCreator.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<DnDCharacterCreator.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Skills.AddOrUpdate(x => x.SkillId,
                    new Skill() { SkillId = 1, SkillName = "Athletics", GovAttribute = "Strength" },
                    new Skill() { SkillId = 2, SkillName = "Acrobatics", GovAttribute = "Dexterity" },
                    new Skill() { SkillId = 3, SkillName = "Sleight of Hand", GovAttribute = "Dexterity" },
                    new Skill() { SkillId = 4, SkillName = "Stealth", GovAttribute = "Dexterity" },
                    new Skill() { SkillId = 5, SkillName = "Arcana", GovAttribute = "Intelligence" },
                    new Skill() { SkillId = 6, SkillName = "History", GovAttribute = "Intelligence" },
                    new Skill() { SkillId = 7, SkillName = "Investigation", GovAttribute = "Intelligence" },
                    new Skill() { SkillId = 8, SkillName = "Nature", GovAttribute = "Intelligence" },
                    new Skill() { SkillId = 9, SkillName = "Religion", GovAttribute = "Intelligence" },
                    new Skill() { SkillId = 10, SkillName = "Animal Handling", GovAttribute = "Wisdom" },
                    new Skill() { SkillId = 11, SkillName = "Insight", GovAttribute = "Wisdom" },
                    new Skill() { SkillId = 12, SkillName = "Medicine", GovAttribute = "Wisdom" },
                    new Skill() { SkillId = 13, SkillName = "Perception", GovAttribute = "Wisdom" },
                    new Skill() { SkillId = 14, SkillName = "Survival", GovAttribute = "Wisdom" },
                    new Skill() { SkillId = 15, SkillName = "Deception", GovAttribute = "Charisma" },
                    new Skill() { SkillId = 16, SkillName = "Intimidation", GovAttribute = "Charisma" },
                    new Skill() { SkillId = 17, SkillName = "Performance", GovAttribute = "Charisma" },
                    new Skill() { SkillId = 18, SkillName = "Persuasion", GovAttribute = "Charisma" }
                    );

            context.Spells.AddOrUpdate(x => x.SpellId,
                    new Spell() { SpellId = 1, SpellName = "Magic Missile", Level = 1, CastTime = "1 action", CastDuration = "Instantaneous", School = "Evocation", Range = 120, DamageType = "Force", Damage = "1d4 + 1", Components = "V, S" },
                    new Spell() { SpellId = 2, SpellName = "Healing Word", Level = 1, CastTime = "1 bonus action", CastDuration = "Instantaneous", School = "Evocation", Range = 60, DamageType = "Healing", Damage = "1d4", Components = "V" },
                    new Spell() { SpellId = 3, SpellName = "Ice Knife", Level = 1, CastTime = "1 action", CastDuration = "Instantaneous", School = "Conjuration", Range = 60, DamageType = "Piercing", Damage = "1d10", Components = "S, M" },
                    new Spell() { SpellId = 4, SpellName = "Charm Person", Level = 1, CastTime = "1 action", CastDuration = "1 Hour", School = "Enchantment", Range = 30, DamageType = "Charmed", Damage = "WIS save", Components = "V, S" },
                    new Spell() { SpellId = 5, SpellName = "Shield", Level = 1, CastTime = "1 reaction", CastDuration = "1 Round", School = "Abjuration", Range = 0, DamageType = "Warding", Damage = "+5 to AC", Components = "V, S" },
                    new Spell() { SpellId = 6, SpellName = "Control Flames", Level = 0, CastTime = "1 action", CastDuration = "Instantaneous", School = "Transmutation", Range = 60, DamageType = "Control", Components = "S" },
                    new Spell() { SpellId = 7, SpellName = "Light", Level = 0, CastTime = "1 action", CastDuration = "1 Hour", School = "Evocation", Range = 20, DamageType = "Creation", Components = "V, M" },
                    new Spell() { SpellId = 8, SpellName = "Mending", Level = 0, CastTime = "1 minute", CastDuration = "Instantaneous", School = "Transmutation", Range = 0, DamageType = "Utility", Components = "V, S, M" },
                    new Spell() { SpellId = 9, SpellName = "Ray of Frost", Level = 0, CastTime = "1 action", CastDuration = "Instantaneous", School = "Evocation", Range = 60, DamageType = "Cold", Damage = "1d8", Components = "V, S" },
                    new Spell() { SpellId = 10, SpellName = "Chill Touch", Level = 0, CastTime = "1 action", CastDuration = "1 Round", School = "Necromancy", Range = 120, DamageType = "Necrotic", Damage = "1d8", Components = "V, S" },
                    new Spell() { SpellId = 11, SpellName = "Minor Illusion", Level = 0, CastTime = "1 action", CastDuration = "1 Minute", School = "Illusion", Range = 30, DamageType = "Control", Components = "S, M" }
                    );
        }
    }
}
