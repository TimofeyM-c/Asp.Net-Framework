namespace ZadanieTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Datebooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tema = c.String(),
                        TimeBegin = c.String(),
                        TimeEnd = c.String(),
                        Adres = c.String(),
                        Description = c.String(),
                        TipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tips", t => t.TipId, cascadeDelete: true)
                .Index(t => t.TipId);
            
            CreateTable(
                "dbo.Tips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Datebooks", "TipId", "dbo.Tips");
            DropIndex("dbo.Datebooks", new[] { "TipId" });
            DropTable("dbo.Tips");
            DropTable("dbo.Datebooks");
        }
    }
}
