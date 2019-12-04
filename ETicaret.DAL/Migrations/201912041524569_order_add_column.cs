namespace ETicaret.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order_add_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "OrderCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "OrderCode");
        }
    }
}
