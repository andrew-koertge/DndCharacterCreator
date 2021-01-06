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
        public Race Races { get; set; }

        public Class Classes { get; set; }

        public Alignment Alignments { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public string Name { get; set; }

    }
}
