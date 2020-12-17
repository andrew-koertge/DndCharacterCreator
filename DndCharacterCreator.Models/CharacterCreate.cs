using DnDCharacterCreator.Data;
using System;
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
        public string Background { get; set; }
    }
}
