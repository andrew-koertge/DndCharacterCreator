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
        public Background Backgrounds { get; set; }
        public Race Races { get; set; }
        public Class Classes { get; set; }
        public Alignment Alignments { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Spell> Spells { get; set; }

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

       
    }
}
