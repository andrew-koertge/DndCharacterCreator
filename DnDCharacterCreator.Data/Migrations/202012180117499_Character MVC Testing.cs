namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CharacterMVCTesting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "Alignments", c => c.Int(nullable: false));
            AddColumn("dbo.Character", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Character", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Character", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Character", "CreatedUtc");
            DropColumn("dbo.Character", "Alignments");
        }
    }
}
