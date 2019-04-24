namespace SkladHW.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductId");
        }
    }
}
