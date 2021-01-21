using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SpellModels
{
    public class SpellDetail
    {
        public int SpellId { get; set; }
        public int Level { get; set; }
        public string SpellName { get; set; }
        public DateTime CastTime { get; set; }
        public DateTime CastDuration { get; set; }
        public int Range { get; set; }
        public string DamageType { get; set; }
    }
}
