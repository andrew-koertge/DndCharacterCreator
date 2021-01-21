using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models.SkillModels
{
    public class SkillCreate
    {
        public string SkillName { get; set; }
        public int SkillThreshold { get; set; }
        public string GovAttribute { get; set; }
    }
}
