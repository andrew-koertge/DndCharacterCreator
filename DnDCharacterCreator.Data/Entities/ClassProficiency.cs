using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterCreator.Data.Entities
{
    public class ClassProficiency
    {
        [Key]
        public int ClassId { get; set; }
        public Class Classes { get; set; }
        public virtual ICollection<Character> Characters { get; set; }
    }
}
