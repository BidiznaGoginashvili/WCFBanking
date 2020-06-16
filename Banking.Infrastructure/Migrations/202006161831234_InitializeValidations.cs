namespace Banking.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UniqueNumber", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UniqueNumber", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
