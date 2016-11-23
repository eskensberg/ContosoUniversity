namespace UniversityBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkingaccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckingAccount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CheckingAccount");
        }
    }
}
