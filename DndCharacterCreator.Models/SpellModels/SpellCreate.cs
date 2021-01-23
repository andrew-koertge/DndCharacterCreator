using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SpellModels
{
    public class SpellCreate
    {
        public int Level { get; set; }
        public string SpellName { get; set; }
        public string CastTime { get; set; }
        public string CastDuration { get; set; }
        public int Range { get; set; }
        public string DamageType { get; set; }
        public string School { get; set; }
        public string Components { get; set; }
        public string Damage { get; set; }
    }
}
