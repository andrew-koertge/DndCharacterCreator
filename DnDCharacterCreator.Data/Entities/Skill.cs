using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnDCharacterCreator.Data
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string GovAttribute { get; set; }
        public bool Selected { get; set; }

        public Skill()
        {
            this.Characters = new HashSet<Character>();
        }
        public virtual ICollection<Character> Characters { get; set; }
    }
}