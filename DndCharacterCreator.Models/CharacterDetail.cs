using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models
{
    public class CharacterDetail
    {
        public string Name { get; set; }
        public string Background { get; set; }
        public Race Races { get; set; }
        public Class Classes { get; set; }
        public Alignment Alignments { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Trait> Traits { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
    }
}
