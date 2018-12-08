namespace OnlineShopMvcWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductImages", "Caption", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductImages", "ImageUrl", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductImages", "ImageUrl", c => c.String());
            AlterColumn("dbo.ProductImages", "Caption", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
