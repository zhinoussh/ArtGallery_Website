namespace website_negaheno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_artGallery_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_art_gallery",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 200),
                        english_title = c.String(maxLength: 200),
                        description = c.String(),
                        fromDate = c.String(maxLength: 10),
                        toDate = c.String(maxLength: 10),
                        fromHour = c.String(maxLength: 5),
                        toHour = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_art_gallery");
        }
    }
}
