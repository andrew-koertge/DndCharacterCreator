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
        public int Level { get; set; }
        public string SpellName { get; set; }
        public string CastTime { get; set; }
        public string CastDuration { get; set; }
        public int Range { get; set; }
        public string DamageType { get; set; }
        public string School { get; set; }
        public string Components { get; set; }
        public string Damage { get; set; }
        public bool Selected { get; set; }

        public Spell()
        {
            this.Characters = new HashSet<Character>();
        }

        public virtual ICollection<Character> Characters { get; set; }
    }
}