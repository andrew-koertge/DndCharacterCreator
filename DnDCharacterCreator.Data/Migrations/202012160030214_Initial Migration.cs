namespace DnDCharacterCreator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        Races = c.Int(nullable: false),
                        Classes = c.Int(nullable: false),
                        Strength = c.Int(nullable: false),
                        Dexterity = c.Int(nullable: false),
                        Constitution = c.Int(nullable: false),
                        Wisdom = c.Int(nullable: false),
                        Intelligence = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Background = c.String(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.ApplicationUser", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        SkillThreshold = c.Int(nullable: false),
                        GovAttribute = c.String(),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Character", t => t.Character_CharacterId)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.Trait",
                c => new
                    {
                        TraitId = c.Int(nullable: false, identity: true),
                        TraitName = c.String(),
                        IsQualified = c.Boolean(nullable: false),
                        Character_CharacterId = c.Int(),
                    })
                .PrimaryKey(t => t.TraitId)
                .ForeignKey("dbo.Character", t => t.Character_CharacterId)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Spell",
                c => new
                    {
                        SpellId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        SpellName = c.String(),
                        CastTime = c.DateTime(nullable: false),
                        CastDuration = c.DateTime(nullable: false),
                        Range = c.Int(nullable: false),
                        DamageType = c.String(),
                    })
                .PrimaryKey(t => t.SpellId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spell", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Trait", "Character_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Skill", "Character_CharacterId", "dbo.Character");
            DropForeignKey("dbo.Character", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Spell", new[] { "CharacterId" });
            DropIndex("dbo.Trait", new[] { "Character_CharacterId" });
            DropIndex("dbo.Skill", new[] { "Character_CharacterId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Character", new[] { "Id" });
            DropTable("dbo.Spell");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Trait");
            DropTable("dbo.Skill");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Character");
        }
    }
}
