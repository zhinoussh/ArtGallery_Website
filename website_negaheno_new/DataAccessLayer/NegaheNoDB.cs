using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using website_negaheno.Models;

namespace website_negaheno.DataAccessLayer
{
    public class NegaheNoDB: DbContext
    {
        public virtual DbSet<tbl_art_gallery> tbl_art_gallery { get; set; }
        public virtual DbSet<tbl_art_galery_photo> tbl_art_gallery_photo { get; set; }
        public virtual DbSet<tbl_photo_album> tbl_photo_album { get; set; }

        public NegaheNoDB()
            : base("name=NegaheNoConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<tbl_art_gallery>()
               .HasMany(e => e.photos)
               .WithOptional(e => e.gallery)
               .HasForeignKey(e => e.GalleryID)
               .WillCascadeOnDelete();

        }
    }
}