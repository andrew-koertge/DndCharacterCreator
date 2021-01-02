using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Models
{
    public class CharacterListItem
    {
        [Display(Name="Race")]
        public Race Races { get; set; }

        [Display(Name="Class")]
        public Class Classes { get; set; }

        [Display(Name="Alignment")]
        public Alignment Alignments { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Name")]
        public string Name { get; set; }

    }
}
