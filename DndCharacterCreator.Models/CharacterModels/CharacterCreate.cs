using DnDCharacterCreator.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models
{
    public class CharacterCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Name must be at least 2 characters long.")]
        [MaxLength(25, ErrorMessage ="Name must be shorter than 25 characters.")]
        public string Name { get; set; }
        public Race Races { get; set; }
        public Class Classes { get; set; }
        public Alignment Alignments { get; set; }
        public string Background { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }

        public int[] Stats = new int[] { 15, 14, 13, 12, 10, 8 };
    }    
}
