namespace PT.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String(maxLength: 55));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetRoles", "Description", c => c.String(maxLength: 25));
        }
    }
}
