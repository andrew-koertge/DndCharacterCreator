using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DnDCharacterCreator.Data
{
    public class Trait
    {
        [Key]
        public int TraitId { get; set; }
        public string TraitName { get; set; }
        public bool IsQualified { get; set; }
    }
}