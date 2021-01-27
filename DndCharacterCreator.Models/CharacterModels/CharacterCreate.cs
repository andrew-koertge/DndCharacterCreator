using DnDCharacterCreator.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DndCharacterCreator.Models
{
    public class CharacterCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage ="Name must be shorter than 50 characters.")]
        public string Name { get; set; }
        public Race Races { get; set; }
        public Class Classes { get; set; }
        public Alignment Alignments { get; set; }
        public Background Backgrounds { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        //public MultiSelectList SpellsList { get; set; }
        //public MultiSelectList SkillsList { get; set; }
        public int StrengthModifier { get; set; }
        public int DexterityModifier { get; set; }
        public int ConstitutionModifier { get; set; }
        public int IntelligenceModifier { get; set; }
        public int WisdomModifier { get; set; }
        public int CharismaModifier { get; set; }

        public string[] ClassProficiency { get; set; }
        public string[] BackgroundProficiency { get; set; }

        public int[] Stats = new int[] { 15, 14, 13, 12, 10, 8 };

        //public int[] SelectedSkills { get; set; }
        //public int[] SelectedSpells { get; set; }
    }    
}
