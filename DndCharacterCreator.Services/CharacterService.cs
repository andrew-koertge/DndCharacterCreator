using DndCharacterCreator.Models;
using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndCharacterCreator.Services
{
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    Name = model.Name,
                    Races = model.Races,
                    Classes = model.Classes,
                    Alignments = model.Alignments,
                    CreatedUtc = DateTimeOffset.Now,
                    Strength = model.Strength,
                    Dexterity = model.Dexterity,
                    Constitution = model.Constitution,
                    Intelligence = model.Intelligence,
                    Wisdom = model.Wisdom,
                    Charisma = model.Charisma
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacter()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters
                    .Where(e => e.Id == _userId.ToString())
                    .Select(
                        e =>
                            new CharacterListItem
                            {
                                Name = e.Name,
                                Races = e.Races,
                                Classes = e.Classes,
                                CreatedUtc = DateTimeOffset.Now
                            }
                     );
                return query.ToArray();
            }
        }
    }
}
