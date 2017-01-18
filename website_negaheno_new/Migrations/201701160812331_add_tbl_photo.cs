namespace website_negaheno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl_photo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_art_galery_photo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        photo_path = c.String(),
                        GalleryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_art_gallery", t => t.GalleryID, cascadeDelete: true)
                .Index(t => t.GalleryID);
            
            AlterColumn("dbo.tbl_art_gallery", "fromDate", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_art_gallery", "toDate", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_art_galery_photo", "GalleryID", "dbo.tbl_art_gallery");
            DropIndex("dbo.tbl_art_galery_photo", new[] { "GalleryID" });
            AlterColumn("dbo.tbl_art_gallery", "toDate", c => c.String(maxLength: 10));
            AlterColumn("dbo.tbl_art_gallery", "fromDate", c => c.String(maxLength: 10));
            DropTable("dbo.tbl_art_galery_photo");
        }
    }
}
