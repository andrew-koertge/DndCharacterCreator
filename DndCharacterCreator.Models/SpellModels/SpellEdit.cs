using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SpellModels
{
    public class SpellEdit
    {
        public string SpellName { get; set; }
        public string CastTime { get; set; }
        public string CastDuration { get; set; }
        public int Range { get; set; }
        public string Damage { get; set; }
    }
}
