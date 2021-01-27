using DnDCharacterCreator.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DnDCharacterCreator.Data
{
    public enum Race
    {
        Dragonborn = 1,
        Dwarf,
        Elf,
        Gnome,
        Half_Elf,
        Halfling,
        Half_Orc,
        Human,
        Tiefling
    }

    public enum Class
    {
        Barbarian = 1,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }

    public enum Alignment
    {
        Lawful_Good = 1,
        Lawful_Neutral,
        Lawful_Evil,
        Neutral_Good,
        True_Neutral,
        Neutral_Evil,
        Chaotic_Good,
        Chaotic_Neutral,
        Chaotic_Evil
    }

    public enum Background
    {
        Acolyte = 1,
        Criminal,
        Folk_Hero,
        Noble,
        Sage,
        Soldier,
    }

    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Race Races { get; set; }
        public Class Classes { get; set; }
        public Background Backgrounds { get; set; }
        public Alignment Alignments { get; set; }

        public virtual ICollection<Spell> Spells { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<ClassProficiency> ClassProficiencies { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public int StrengthModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int ConstitutionModifier { get; set; }
        public int IntelligenceModifier { get; set; }
        public int WisdomModifier { get; set; }
        public int CharismaModifier { get; set; }

        public string Name { get; set; }
       
        public DateTimeOffset CreatedUtc { get; set; }

        public Character()
        {
            this.Spells = new HashSet<Spell>();
            this.Skills = new HashSet<Skill>();
            this.ClassProficiencies = new HashSet<ClassProficiency>();
        }
    }
}