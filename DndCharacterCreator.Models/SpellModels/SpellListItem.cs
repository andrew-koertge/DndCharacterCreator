using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SpellModels
{
    public class SpellListItem
    {
        [Required]
        public int SpellId { get; set; }
        public int Level { get; set; }
        public string SpellName { get; set; }
        public string CastTime { get; set; }
        public string CastDuration { get; set; }
        public int Range { get; set; }
        public string DamageType { get; set; }
    }
}
