﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace artgallery.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineArtGalleryEntities : DbContext
    {
        public OnlineArtGalleryEntities()
            : base("name=OnlineArtGalleryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adminbox> Adminboxes { get; set; }
        public virtual DbSet<ArtGallery> ArtGalleries { get; set; }
        public virtual DbSet<ArtInvoice> ArtInvoices { get; set; }
        public virtual DbSet<AuctionGallery> AuctionGalleries { get; set; }
        public virtual DbSet<AuctionInvoice> AuctionInvoices { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}
