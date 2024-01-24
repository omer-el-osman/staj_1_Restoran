﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyData.repo;

#nullable disable

namespace MyData.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20231126111757_MyYeni")]
    partial class MyYeni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyClasses.AnaSayfaMessajleri", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Messaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("anaSayfaMessajleris");
                });

            modelBuilder.Entity("MyClasses.Kullanici", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Adı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Confirme_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Email_Onaylama")
                        .HasColumnType("bit");

                    b.Property<string>("SoyAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("kullanicilar");
                });

            modelBuilder.Entity("MyClasses.Masalar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("Mycheck")
                        .HasColumnType("bit");

                    b.Property<string>("SubeAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("masalar")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("masalars");
                });

            modelBuilder.Entity("MyClasses.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Adı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Check")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoyAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Teslim_Kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yemek_Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Yemek_Kategorisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("durum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("fiyat")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("MyClasses.Reservasyon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Adı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Durum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Masa_num")
                        .HasColumnType("int");

                    b.Property<string>("SoyAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubeAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("tarih")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("reservasyons");
                });

            modelBuilder.Entity("MyClasses.Subeler", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubeAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("masalar")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("subelers");
                });

            modelBuilder.Entity("MyClasses.yemekKatigorisi", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Katigori")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("yemekKatigorisis");
                });

            modelBuilder.Entity("MyClasses.yemekMenusu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Yemek_Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Yemek_Kategorisi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("fiyat")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("yemekMenusus");
                });
#pragma warning restore 612, 618
        }
    }
}
