using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyData.Migrations
{
    public partial class MyYeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anaSayfaMessajleris",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Messaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anaSayfaMessajleris", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoyAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email_Onaylama = table.Column<bool>(type: "bit", nullable: false),
                    Confirme_password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "masalars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    masalar = table.Column<int>(type: "int", nullable: false),
                    Mycheck = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_masalars", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoyAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yemek_Kategorisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yemek_Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fiyat = table.Column<float>(type: "real", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Check = table.Column<bool>(type: "bit", nullable: false),
                    durum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teslim_Kodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservasyons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoyAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Masa_num = table.Column<int>(type: "int", nullable: false),
                    tarih = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservasyons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subelers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    masalar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subelers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yemekKatigorisis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Katigori = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yemekKatigorisis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yemekMenusus",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yemek_Kategorisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yemek_Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fiyat = table.Column<float>(type: "real", nullable: false),
                    Resim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yemekMenusus", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anaSayfaMessajleris");

            migrationBuilder.DropTable(
                name: "kullanicilar");

            migrationBuilder.DropTable(
                name: "masalars");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "reservasyons");

            migrationBuilder.DropTable(
                name: "subelers");

            migrationBuilder.DropTable(
                name: "yemekKatigorisis");

            migrationBuilder.DropTable(
                name: "yemekMenusus");
        }
    }
}
