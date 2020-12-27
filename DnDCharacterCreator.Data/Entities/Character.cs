﻿using System;
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
        HalfElf,
        Halfling,
        HalfOrc,
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
        LawfulGood = 1,
        LawfulNeutral,
        LawfulEvil,
        NeutralGood,
        TrueNeutral,
        NeutralEvil,
        ChaoticGood,
        ChaoticNeutral,
        ChaoticEvil
    }

    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public Race Races { get; set; }
        
        public Class Classes { get; set; }

        public Alignment Alignments { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public string Name { get; set; }
        public string Background { get; set; }
        public ICollection<Trait> Traits { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}