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
        public DbSet<Declaration> Declarations { get; set; }
        public DbSet<SiteContent> SiteContents { get; set; }
        public DbSet<SiteContentType> SiteContentTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Attributes> Attributes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
		public DbSet<Language> Languages { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<PromoCodes> PromoCodes { get; set; }
		public DbSet<Materials> Materials { get; set; }
		public DbSet<Profiles> Profiles { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<CategoryType> CategoryTypes { get; set; }
		public DbSet<DoorHandle> DoorHandles { get; set; }
		public DbSet<MaterialColor> MaterialColors { get; set; }
		public DbSet<OpeningStyle> OpeningStyles { get; set; }
		public DbSet<Glazing> Glazings { get; set; }
		public DbSet<ProductDetails> ProductDetails { get; set; }


        #endregion MainDataDataSET

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

				entity.HasOne(x => x.Declaration)
				.WithMany(x => x.Products)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Language)
					  .WithMany(x => x.Products)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<ProductAttributes>(entity =>
			{
				entity.HasKey(x => x.ProductAttributeId);

				entity.HasOne(x => x.Attributes)
				.WithMany(x => x.ProductAttributes)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Product)
				.WithMany(x => x.ProductAttributes)
				.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Categories>(entity =>
			{
				entity.HasKey(x => x.CategoryId);

				entity.HasOne(x => x.Seo)
				.WithMany(x => x.Categories)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Media)
				.WithMany(x => x.Categories)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Languages)
					  .WithMany(x => x.Categories)
					  .OnDelete(DeleteBehavior.Restrict);
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

				entity.HasOne(x => x.Language)
					  .WithMany(x => x.Seos)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Declaration>(entity =>
			{
				entity.HasKey(x => x.DeclarationId);

				entity.HasOne(x => x.Language)
					  .WithMany(x => x.Declarations)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Tag>(entity =>
			{
				entity.HasKey(x => x.TagId);

				entity.HasOne(x => x.Media)
				.WithMany(x => x.Tags)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Language)
					  .WithMany(x => x.Tags)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<SiteContent>(entity =>
			{
				entity.HasKey(x => x.SiteContentId);

				entity.HasOne(x => x.Seo)
				.WithMany(x => x.SiteContents)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Tag)
				.WithMany(x => x.SiteContents)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Media)
				.WithMany(x => x.SiteContents)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.SiteContentType)
				.WithMany(x => x.SiteContents)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Language)
					  .WithMany(x => x.SiteContents)
					  .OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<SiteContentType>(entity =>
			{
				entity.HasKey(x => x.SiteContentTypeId);
			});

			modelBuilder.Entity<Order>(entity =>
			{
				entity.HasKey(x => x.OrderId);

				entity.HasOne(x => x.Users)
				.WithMany(x => x.Orders)
				.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<OrderDetails>(entity =>
			{
				entity.HasKey(x => x.OrderDetailsId);

				entity.HasOne(x => x.Order)
			   .WithMany(x => x.OrderDetails)
			   .OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Product)
			   .WithMany(x => x.OrderDetails)
			   .OnDelete(DeleteBehavior.Restrict);
			});
			modelBuilder.Entity<Attributes>(entity =>
			{
				entity.HasKey(x => x.AttributesId);

                entity.HasOne(x => x.Categories)
                .WithMany(x => x.Attributes)
                .OnDelete(DeleteBehavior.Restrict);
            });
			modelBuilder.Entity<Invoice>(entity =>
			{
				entity.HasKey(x => x.InvoiceId);

				entity.HasOne(x => x.Media)
				.WithMany(x => x.Invoices)
				.OnDelete(DeleteBehavior.Restrict);
			});
            modelBuilder.Entity<Newsletter>(entity =>
            {
                entity.HasKey(x => x.NewsletterId);
            });
			modelBuilder.Entity<Materials>(entity =>
			{
				entity.HasKey(x => x.MaterialId);
			});
			modelBuilder.Entity<Profiles>(entity =>
			{
				entity.HasKey(entity => entity.ProfileId);

				entity.HasOne(x => x.Category)
				.WithMany(x => x.Profiles)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Brand)
				.WithMany(x => x.Profiles)
				.OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Media)
				.WithMany(x => x.Profiles)
				.OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Material)
				.WithMany(x => x.Profiles)
				.OnDelete(DeleteBehavior.Restrict);
            });
			modelBuilder.Entity<Brand>(entity =>
			{
				entity.HasKey(x => x.BrandId);
			});
			modelBuilder.Entity<CategoryType>(entity =>
			{
				entity.HasKey(x => x.CategoryTypeId);

				entity.HasOne(x => x.Category)
			   .WithMany(x => x.CategoryTypes)
			   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Media)
               .WithMany(x => x.CategoryTypes)
               .OnDelete(DeleteBehavior.Restrict);
            });
			modelBuilder.Entity<DoorHandle>(entity =>
			{
				entity.HasKey(x => x.DoorHandleId);

				entity.HasOne(x => x.Material)
			   .WithMany(x => x.DoorHandles)
			   .OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Media)
			   .WithMany(x => x.DoorHandles)
			   .OnDelete(DeleteBehavior.Restrict);
			});
			modelBuilder.Entity<MaterialColor>(entity =>
			{
				entity.HasKey(x => x.MaterialColorId);

				entity.HasOne(x => x.Material)
			   .WithMany(x => x.MaterialColors)
			   .OnDelete(DeleteBehavior.Restrict);
			});
			modelBuilder.Entity<OpeningStyle>(entity =>
			{
				entity.HasKey(x => x.OpeningStyleId);

				entity.HasOne(x => x.CategoryType)
			   .WithMany(x => x.OpeningStyles)
			   .OnDelete(DeleteBehavior.Restrict);

				entity.HasOne(x => x.Media)
			   .WithMany(x => x.OpeningStyles)
			   .OnDelete(DeleteBehavior.Restrict);
			});
            modelBuilder.Entity<Glazing>(entity =>
            {
                entity.HasKey(x => x.GlazingId);

                entity.HasOne(x => x.Media)
               .WithMany(x => x.Glazings)
               .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<ProductDetails>(entity =>
            {
                entity.HasKey(x => x.ProductDetailsId);

                entity.HasOne(x => x.Category)
               .WithMany(x => x.ProductDetails)
               .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Profile)
              .WithMany(x => x.ProductDetails)
              .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Media)
              .WithMany(x => x.ProductDetails)
			  .HasForeignKey(x => x.Draft)
              .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}