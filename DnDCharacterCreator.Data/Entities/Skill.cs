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
        public int SkillThreshold { get; set; }
        public string GovAttribute { get; set; }
    }
}