namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedmanytomanyrelationshipbetweencharandspell : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spell", "CharacterId", "dbo.Character");
            DropIndex("dbo.Spell", new[] { "CharacterId" });
            CreateTable(
                "dbo.CharacterSpells",
                c => new
                    {
                        CharacterId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CharacterId, t.SpellId })
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Spell", t => t.SpellId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.SpellId);
            
            DropColumn("dbo.Spell", "CharacterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Spell", "CharacterId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CharacterSpells", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.CharacterSpells", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharacterSpells", new[] { "SpellId" });
            DropIndex("dbo.CharacterSpells", new[] { "CharacterId" });
            DropTable("dbo.CharacterSpells");
            CreateIndex("dbo.Spell", "CharacterId");
            AddForeignKey("dbo.Spell", "CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
        }
    }
}
