using DndCharacterCreator.Models;
using DndCharacterCreator.Models.CharacterModels;
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
                    Id = _userId.ToString(),
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
                                CharacterId = e.CharacterId,
                                Name = e.Name,
                                Races = e.Races,
                                Classes = e.Classes,
                                CreatedUtc = e.CreatedUtc
                            }
                     );
                return query.ToArray();
            }
        }

        public IEnumerable<CharacterDetail> Details(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters
                    .Where(e => e.CharacterId == charId && e.Id == _userId.ToString())
                    .Select(
                        e =>
                        new CharacterDetail
                        {
                            Name = e.Name,
                            Backgrounds = e.Backgrounds,
                            Races = e.Races,
                            Classes = e.Classes,
                            Alignments = e.Alignments,
                            CreatedUtc = e.CreatedUtc,
                            Strength = e.Strength,
                            Dexterity = e.Dexterity,
                            Constitution = e.Constitution,
                            Intelligence = e.Intelligence,
                            Wisdom = e.Wisdom,
                            Charisma = e.Charisma
                        }
                    );
                return query.ToArray();
            }
        }

        public IEnumerable<CharacterEdit> Edit(int charId)
        {
             using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == charId && e.Id == _userId.ToString());

                
            }
        } 

        public bool Delete(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == charId && e.Id == _userId.ToString());

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
