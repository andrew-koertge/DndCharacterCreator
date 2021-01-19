namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedbackgroundtoenum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "Backgrounds", c => c.Int(nullable: false));
            DropColumn("dbo.Character", "Background");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "Background", c => c.String());
            DropColumn("dbo.Character", "Backgrounds");
        }
    }
}
