﻿// <auto-generated />
using System;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20240816062929_materialEntity_added")]
    partial class materialEntity_added
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Universal.MainData.Attributes", b =>
                {
                    b.Property<int>("AttributesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributesId"));

                    b.Property<int?>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAttribute")
                        .HasColumnType("bit");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("LanguageID");

                    b.HasIndex("MediaId");

                    b.HasIndex("SeoId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Declaration", b =>
                {
                    b.Property<int>("DeclarationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeclarationId"));

                    b.Property<string>("ConsumerRights")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeclarationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distributor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAndTypeOfProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeclarationId");

                    b.HasIndex("LanguageID");

                    b.ToTable("Declarations");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("PdfName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("InvoiceId");

                    b.HasIndex("MediaId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Language", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageID"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Materials", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"));

                    b.Property<string>("MaterialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaterialPrice")
                        .HasColumnType("float");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaId"));

                    b.Property<string>("AltTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaId");

                    b.HasIndex("MediaTypeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Entities.Universal.MainData.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaTypeId"));

                    b.Property<string>("MediaTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Newsletter", b =>
                {
                    b.Property<int>("NewsletterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsletterId"));

                    b.Property<string>("NewsletterMail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NewsletterId");

                    b.ToTable("Newsletters");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UsersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entities.Universal.MainData.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailsId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<bool>("BestProduct")
                        .HasColumnType("bit");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeclarationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Recommended")
                        .HasColumnType("bit");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoriesId");

                    b.HasIndex("DeclarationId");

                    b.HasIndex("LanguageID");

                    b.HasIndex("SeoId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Entities.Universal.MainData.ProductAttributes", b =>
                {
                    b.Property<int>("ProductAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductAttributeId"));

                    b.Property<int?>("AttributesId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDev")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductAttributeId");

                    b.HasIndex("AttributesId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.PromoCodes", b =>
                {
                    b.Property<int>("PromoCodesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromoCodesId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromoCodeValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PromoCodesId");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SaleTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaleId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleTypeId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SaleType", b =>
                {
                    b.Property<int>("SaleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleTypeId"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaleTypeId");

                    b.ToTable("SaleTypes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Seo", b =>
                {
                    b.Property<int>("SeoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeoId"));

                    b.Property<string>("GoogleDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.HasKey("SeoId");

                    b.HasIndex("LanguageID");

                    b.ToTable("Seos");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SiteContent", b =>
                {
                    b.Property<int>("SiteContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteContentId"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<int?>("SeoId")
                        .HasColumnType("int");

                    b.Property<int?>("SiteContentTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("TagId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteContentId");

                    b.HasIndex("LanguageID");

                    b.HasIndex("MediaId");

                    b.HasIndex("SeoId");

                    b.HasIndex("SiteContentTypeId");

                    b.HasIndex("TagId");

                    b.ToTable("SiteContents");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SiteContentType", b =>
                {
                    b.Property<int>("SiteContentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteContentTypeId"));

                    b.Property<string>("SiteContentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteContentTypeId");

                    b.ToTable("SiteContentTypes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LanguageID")
                        .HasColumnType("int");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.HasIndex("LanguageID");

                    b.HasIndex("MediaId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MediaId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.HasIndex("MediaId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Attributes", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Categories", "Categories")
                        .WithMany("Attributes")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Categories", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Language", "Languages")
                        .WithMany("Categories")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Media", "Media")
                        .WithMany("Categories")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Seo", "Seo")
                        .WithMany("Categories")
                        .HasForeignKey("SeoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Languages");

                    b.Navigation("Media");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Declaration", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Language", "Language")
                        .WithMany("Declarations")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Invoice", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Media", "Media")
                        .WithMany("Invoices")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Media", b =>
                {
                    b.HasOne("Entities.Universal.MainData.MediaType", "MediaType")
                        .WithMany("Medias")
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Universal.MainData.Product", "Product")
                        .WithMany("Medias")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("MediaType");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Order", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Users", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.Universal.MainData.OrderDetails", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Universal.MainData.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Product", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Categories", "Categories")
                        .WithMany("Products")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Universal.MainData.Declaration", "Declaration")
                        .WithMany("Products")
                        .HasForeignKey("DeclarationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Language", "Language")
                        .WithMany("Products")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Seo", "Seo")
                        .WithMany("Products")
                        .HasForeignKey("SeoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Categories");

                    b.Navigation("Declaration");

                    b.Navigation("Language");

                    b.Navigation("Seo");
                });

            modelBuilder.Entity("Entities.Universal.MainData.ProductAttributes", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Attributes", "Attributes")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("AttributesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Product", "Product")
                        .WithMany("ProductAttributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Attributes");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Sale", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Universal.MainData.SaleType", "SaleType")
                        .WithMany("Sales")
                        .HasForeignKey("SaleTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleType");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Seo", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Language", "Language")
                        .WithMany("Seos")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SiteContent", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Language", "Language")
                        .WithMany("SiteContents")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Media", "Media")
                        .WithMany("SiteContents")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Seo", "Seo")
                        .WithMany("SiteContents")
                        .HasForeignKey("SeoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.SiteContentType", "SiteContentType")
                        .WithMany("SiteContents")
                        .HasForeignKey("SiteContentTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Tag", "Tag")
                        .WithMany("SiteContents")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Language");

                    b.Navigation("Media");

                    b.Navigation("Seo");

                    b.Navigation("SiteContentType");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Tag", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Language", "Language")
                        .WithMany("Tags")
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Entities.Universal.MainData.Media", "Media")
                        .WithMany("Tags")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Language");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Users", b =>
                {
                    b.HasOne("Entities.Universal.MainData.Media", "Media")
                        .WithMany("Users")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Media");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Attributes", b =>
                {
                    b.Navigation("ProductAttributes");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Categories", b =>
                {
                    b.Navigation("Attributes");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Declaration", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Language", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Declarations");

                    b.Navigation("Products");

                    b.Navigation("Seos");

                    b.Navigation("SiteContents");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Media", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Invoices");

                    b.Navigation("SiteContents");

                    b.Navigation("Tags");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Entities.Universal.MainData.MediaType", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Product", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("OrderDetails");

                    b.Navigation("ProductAttributes");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SaleType", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Seo", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("SiteContents");
                });

            modelBuilder.Entity("Entities.Universal.MainData.SiteContentType", b =>
                {
                    b.Navigation("SiteContents");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Tag", b =>
                {
                    b.Navigation("SiteContents");
                });

            modelBuilder.Entity("Entities.Universal.MainData.Users", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
