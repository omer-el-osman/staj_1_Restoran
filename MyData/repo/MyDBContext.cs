using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyClasses;

namespace MyData.repo
{
    public class MyDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5UO08KH;Database=Restoran;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false");
        }
        //EntityFrameworkCore\Add-Migration MyKullanici -Context MyData.repo.MyDBContext
        //EntityFrameworkCore\update-database -Context MyData.repo.MyDBContext

        public DbSet<Kullanici> ? kullanicilar { get; set; }
        public DbSet<Subeler> ? subelers { get; set; }
        public DbSet<yemekMenusu>? yemekMenusus { get; set; }
        public DbSet<yemekKatigorisi> ? yemekKatigorisis { get; set; }
        public DbSet<AnaSayfaMessajleri> ?  anaSayfaMessajleris { get; set; }
        public DbSet<Masalar> ?  masalars { get; set; }
   
        public DbSet<Reservasyon> ?  reservasyons { get; set; }
        public DbSet<Order>? orders { get; set; }
    }
}
