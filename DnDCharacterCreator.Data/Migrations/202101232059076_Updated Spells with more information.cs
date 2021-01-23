namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSpellswithmoreinformation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skill", "Character_CharacterId", "dbo.Character");
            DropIndex("dbo.Skill", new[] { "Character_CharacterId" });
            CreateTable(
                "dbo.CharacterSkills",
                c => new
                    {
                        CharacterId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CharacterId, t.SkillId })
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Skill", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.SkillId);
            
            AddColumn("dbo.Spell", "School", c => c.String());
            AddColumn("dbo.Spell", "Components", c => c.String());
            AddColumn("dbo.Spell", "Damage", c => c.String());
            AlterColumn("dbo.Spell", "CastTime", c => c.String());
            AlterColumn("dbo.Spell", "CastDuration", c => c.String());
            DropColumn("dbo.Skill", "Character_CharacterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skill", "Character_CharacterId", c => c.Int());
            DropForeignKey("dbo.CharacterSkills", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.CharacterSkills", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharacterSkills", new[] { "SkillId" });
            DropIndex("dbo.CharacterSkills", new[] { "CharacterId" });
            AlterColumn("dbo.Spell", "CastDuration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Spell", "CastTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Spell", "Damage");
            DropColumn("dbo.Spell", "Components");
            DropColumn("dbo.Spell", "School");
            DropTable("dbo.CharacterSkills");
            CreateIndex("dbo.Skill", "Character_CharacterId");
            AddForeignKey("dbo.Skill", "Character_CharacterId", "dbo.Character", "CharacterId");
        }
    }
}
