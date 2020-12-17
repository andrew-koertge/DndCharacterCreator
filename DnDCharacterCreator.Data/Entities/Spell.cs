using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DnDCharacterCreator.Data 
{ 
    public class Spell
    {
        [Key]
        public int SpellId { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int Level { get; set; }
        public string SpellName { get; set; }
        public DateTime CastTime { get; set; }
        public DateTime CastDuration { get; set; }
        public int Range { get; set; }
        public string DamageType { get; set; }

    }
}