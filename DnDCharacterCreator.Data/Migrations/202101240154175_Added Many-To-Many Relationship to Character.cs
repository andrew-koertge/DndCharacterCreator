namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManyToManyRelationshiptoCharacter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trait", "Character_CharacterId", "dbo.Character");
            DropIndex("dbo.Trait", new[] { "Character_CharacterId" });
            DropTable("dbo.Trait");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trait",
                c => new
                    {
                        TraitId = c.Int(nullable: false, identity: true),
                        TraitName = c.String(),
                        IsQualified = c.Boolean(nullable: false),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.TraitId);
            
            CreateIndex("dbo.Trait", "Character_CharacterId");
            AddForeignKey("dbo.Trait", "Character_CharacterId", "dbo.Character", "CharacterId");
        }
    }
}
