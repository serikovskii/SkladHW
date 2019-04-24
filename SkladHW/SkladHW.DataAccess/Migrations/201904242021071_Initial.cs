namespace SkladHW.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameProduct = c.String(),
                        PriceProduct = c.Int(nullable: false),
                        DateDelete = c.DateTime(),
                        OldNameProduct = c.String(),
                        OldPriceProduct = c.Int(),
                        DateUpdate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
