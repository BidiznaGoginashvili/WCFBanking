namespace Banking.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.Byte(nullable: false),
                        UniqueNumber = c.String(nullable: false, maxLength: 11),
                        BirthDay = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        Email = c.String(nullable: false),
                        Phone = c.String(maxLength: 50),
                        Role_Id = c.Int(),
                        Branches_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Branches", t => t.Branches_Id)
                .Index(t => t.Role_Id)
                .Index(t => t.Branches_Id);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MonthlyPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        GuarantorId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guarantors", t => t.GuarantorId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.GuarantorId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Guarantors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Relationship = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Branches_Id", "dbo.Branches");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Loans", "UserId", "dbo.Users");
            DropForeignKey("dbo.Loans", "GuarantorId", "dbo.Guarantors");
            DropForeignKey("dbo.Deposits", "UserId", "dbo.Users");
            DropIndex("dbo.Loans", new[] { "UserId" });
            DropIndex("dbo.Loans", new[] { "GuarantorId" });
            DropIndex("dbo.Deposits", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Branches_Id" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.Guarantors");
            DropTable("dbo.Loans");
            DropTable("dbo.Deposits");
            DropTable("dbo.Users");
            DropTable("dbo.Branches");
        }
    }
}
