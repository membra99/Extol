﻿using Entities.Universal.MainData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Context
{
    public partial class MainContext : DbContext
    {
        #region MainDataDataSET

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttributes> ProductAttributes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleType> SaleTypes { get; set; }
        public DbSet<Seo> Seos { get; set; }


        #endregion

        private void UniversalModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);

                entity.HasOne(x => x.Categories)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Seo)
                .WithMany(x => x.Products)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductAttributes>(entity =>
            {
                entity.HasKey(x => x.ProductAttributeId);

                entity.HasOne(x => x.Categories)
                .WithMany(x => x.ProductAttributes)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Product)
                .WithMany(x => x.ProductAttributes)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(x => x.CategoryId);
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.HasKey(x => x.MediaTypeId);
            });

            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(x => x.MediaId);

                entity.HasOne(x => x.MediaType)
                .WithMany(x => x.Medias)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Product)
                .WithMany(x => x.Medias)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(x => x.UsersId);

                entity.HasOne(x => x.Media)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<SaleType>(entity =>
            {
                entity.HasKey(x => x.SaleTypeId);

            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(x => x.SaleId);

                entity.HasOne(x => x.Product)
                .WithMany(x => x.Sales)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SaleType)
                .WithMany(x => x.Sales)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Seo>(entity =>
            {
                entity.HasKey(x => x.SeoId);

            });
        }
    }
}
