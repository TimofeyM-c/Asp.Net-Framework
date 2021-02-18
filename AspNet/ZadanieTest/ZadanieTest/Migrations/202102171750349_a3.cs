namespace ZadanieTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Datebooks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Datebooks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Tips", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tips", "Name", c => c.String());
            AlterColumn("dbo.Datebooks", "Description", c => c.String());
            AlterColumn("dbo.Datebooks", "Name", c => c.String());
        }
    }
}
