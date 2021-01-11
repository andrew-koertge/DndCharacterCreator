namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedUserIndexError : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Character", new[] { "Id" });
            AlterColumn("dbo.Character", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Character", "Id");
            AddForeignKey("dbo.Character", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Character", new[] { "Id" });
            AlterColumn("dbo.Character", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Character", "Id");
            AddForeignKey("dbo.Character", "Id", "dbo.ApplicationUser", "Id");
        }
    }
}
