using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.CharacterModels
{
    public class CharacterEdit
    {
        public Alignment Alignments { get; set; }
        public ICollection<Spell> Spells { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }
}
