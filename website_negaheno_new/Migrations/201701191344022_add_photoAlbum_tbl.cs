namespace website_negaheno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_photoAlbum_tbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_photo_album",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        file_path = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_photo_album");
        }
    }
}
