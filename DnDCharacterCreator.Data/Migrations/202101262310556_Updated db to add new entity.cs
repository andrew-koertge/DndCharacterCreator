namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateddbtoaddnewentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassProficiency",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Classes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.ClassProficiencyCharacter",
                c => new
                    {
                        ClassProficiency_ClassId = c.Int(nullable: false),
                        Character_CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ClassProficiency_ClassId, t.Character_CharacterId })
                .ForeignKey("dbo.ClassProficiency", t => t.ClassProficiency_ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.Character_CharacterId, cascadeDelete: true)
                .Index(t => t.ClassProficiency_ClassId)
                .Index(t => t.Character_CharacterId);
            
            AddColumn("dbo.Character", "StrengthModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "DexterityModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "ConstitutionModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "IntelligenceModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "WisdomModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "CharismaModifier", c => c.Int(nullable: false));
            AddColumn("dbo.Skill", "Selected", c => c.Boolean(nullable: false));
            AddColumn("dbo.Spell", "Selected", c => c.Boolean(nullable: false));
            DropColumn("dbo.Skill", "SkillThreshold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skill", "SkillThreshold", c => c.Int(nullable: false));
            DropForeignKey("dbo.ClassProficiencyCharacter", "Character_CharacterId", "dbo.Character");
            DropForeignKey("dbo.ClassProficiencyCharacter", "ClassProficiency_ClassId", "dbo.ClassProficiency");
            DropIndex("dbo.ClassProficiencyCharacter", new[] { "Character_CharacterId" });
            DropIndex("dbo.ClassProficiencyCharacter", new[] { "ClassProficiency_ClassId" });
            DropColumn("dbo.Spell", "Selected");
            DropColumn("dbo.Skill", "Selected");
            DropColumn("dbo.Character", "CharismaModifier");
            DropColumn("dbo.Character", "WisdomModifier");
            DropColumn("dbo.Character", "IntelligenceModifier");
            DropColumn("dbo.Character", "ConstitutionModifier");
            DropColumn("dbo.Character", "DexterityModifier");
            DropColumn("dbo.Character", "StrengthModifier");
            DropTable("dbo.ClassProficiencyCharacter");
            DropTable("dbo.ClassProficiency");
        }
    }
}
