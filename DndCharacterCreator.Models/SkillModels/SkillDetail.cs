using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SkillModels
{
    public class SkillDetail
    {
        [Required]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillThreshold { get; set; }
        public string GovAttribute { get; set; }
    }
}
