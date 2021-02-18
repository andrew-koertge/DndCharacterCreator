using DndCharacterCreator.Models;
using DndCharacterCreator.Models.CharacterModels;
using DnDCharacterCreator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DndCharacterCreator.Services
{
    public class CharacterService
    {
        private readonly Guid _userId;

        private ApplicationDbContext _db = new ApplicationDbContext();

        public CharacterCreate Character { get; }

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public CharacterService(Character character)
        {
            
        }

        public CharacterService(CharacterCreate character)
        {
            Character = character;
        }

        public void CalculateModifiers(CharacterCreate character)
        {
            using (var ctx = new ApplicationDbContext())
            {
                switch (character.Strength)
                {
                    case 15:
                        character.StrengthModifier = 2;
                        break;
                    case 14:
                        character.StrengthModifier = 2;
                        break;
                    case 13:
                        character.StrengthModifier = 1;
                        break;
                    case 12:
                        character.StrengthModifier = 1;
                        break;
                    case 10:
                        character.StrengthModifier = 0;
                        break;
                    case 8:
                        character.StrengthModifier = -1;
                        break;
                }

                switch (character.Dexterity)
                {
                    case 15:
                        character.DexterityModifier = 2;
                        break;
                    case 14:
                        character.DexterityModifier = 2;
                        break;
                    case 13:
                        character.DexterityModifier = 1;
                        break;
                    case 12:
                        character.DexterityModifier = 1;
                        break;
                    case 10:
                        character.DexterityModifier = 0;
                        break;
                    case 8:
                        character.DexterityModifier = -1;
                        break;
                }

                switch (character.Constitution)
                {
                    case 15:
                        character.ConstitutionModifier = 2;
                        break;
                    case 14:
                        character.ConstitutionModifier = 2;
                        break;
                    case 13:
                        character.ConstitutionModifier = 1;
                        break;
                    case 12:
                        character.ConstitutionModifier = 1;
                        break;
                    case 10:
                        character.ConstitutionModifier = 0;
                        break;
                    case 8:
                        character.ConstitutionModifier = -1;
                        break;
                }

                switch (character.Intelligence)
                {
                    case 15:
                        character.IntelligenceModifier = 2;
                        break;
                    case 14:
                        character.IntelligenceModifier = 2;
                        break;
                    case 13:
                        character.IntelligenceModifier = 1;
                        break;
                    case 12:
                        character.IntelligenceModifier = 1;
                        break;
                    case 10:
                        character.IntelligenceModifier = 0;
                        break;
                    case 8:
                        character.IntelligenceModifier = -1;
                        break;
                }

                switch (character.Wisdom)
                {
                    case 15:
                        character.WisdomModifier = 2;
                        break;
                    case 14:
                        character.WisdomModifier = 2;
                        break;
                    case 13:
                        character.WisdomModifier = 1;
                        break;
                    case 12:
                        character.WisdomModifier = 1;
                        break;
                    case 10:
                        character.WisdomModifier = 0;
                        break;
                    case 8:
                        character.WisdomModifier = -1;
                        break;
                }

                switch (character.Charisma)
                {
                    case 15:
                        character.CharismaModifier = 2;
                        break;
                    case 14:
                        character.CharismaModifier = 2;
                        break;
                    case 13:
                        character.CharismaModifier = 1;
                        break;
                    case 12:
                        character.CharismaModifier = 1;
                        break;
                    case 10:
                        character.CharismaModifier = 0;
                        break;
                    case 8:
                        character.CharismaModifier = -1;
                        break;
                }

                ctx.SaveChanges();
            }
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
                    Charisma = model.Charisma,
                };
            
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public void SkillProficiency(CharacterCreate character)
        {
            switch (character.Classes)
            {
                case Class.Barbarian:
                    
                    break;
                case Class.Bard:
                    break;
                case Class.Cleric:
                    break;
                case Class.Druid:
                    break;
                case Class.Fighter:
                    break;
                case Class.Monk:
                    break;
                case Class.Paladin:
                    break;
                case Class.Ranger:
                    break;
                case Class.Rogue:
                    break;
                case Class.Sorcerer:
                    break;
                case Class.Warlock:
                    break;
                case Class.Wizard:
                    break;
            }
                
        }

        //public void CreateSkills()
        //{
        //    var model = new CharacterCreate();

        //    var skills = _db.Skills.Select(s => new 
        //    {
        //        s.SkillId,
        //        s.SkillName
        //    }).ToList();

        //    model.SkillsList = new MultiSelectList(skills, "SkillId", "SkillName");
        //}
        
        //public void CreateSpells()
        //{
        //    var model = new CharacterCreate();

        //    var spells = _db.Spells.Select(s => new
        //    {
        //        s.SpellId,
        //        s.SpellName
        //    }).ToList();

        //    model.SpellsList = new MultiSelectList(spells, "SpellId", "SpellName");
        //}

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

        public CharacterDetail Details(int charId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == charId && e.Id == _userId.ToString());

                    return new CharacterDetail
                    {
                        Name = entity.Name,
                        Backgrounds = entity.Backgrounds,
                        Races = entity.Races,
                        Classes = entity.Classes,
                        Alignments = entity.Alignments,
                        CreatedUtc = entity.CreatedUtc,
                        Strength = entity.Strength,
                        Dexterity = entity.Dexterity,
                        Constitution = entity.Constitution,
                        Intelligence = entity.Intelligence,
                        Wisdom = entity.Wisdom,
                        Charisma = entity.Charisma,
                        StrengthModifier = entity.StrengthModifier,
                        DexterityModifier = entity.DexterityModifier,
                        ConstitutionModifier = entity.ConstitutionModifier,
                        IntelligenceModifier = entity.IntelligenceModifier,
                        WisdomModifier = entity.WisdomModifier,
                        CharismaModifier = entity.CharismaModifier
                    };
            }
        }

        public IEnumerable<CharacterEdit> Edit(int charId)
        {
             using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters
                    .Where(e => e.CharacterId == charId && e.Id == _userId.ToString())
                    .Select(
                        e =>
                        new CharacterEdit
                        {
                            Alignments = e.Alignments,
                            Skills = e.Skills,
                            Spells = e.Spells
                        }
                    );
                return query.ToArray();
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
