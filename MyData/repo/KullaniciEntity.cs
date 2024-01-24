using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;

namespace MyData.repo
{
    public class KullaniciEntity : Ihelper<Kullanici>
    {
        private MyDBContext db;
        private Kullanici Kullanici;
        public KullaniciEntity()
        {

            db = new MyDBContext();
            Kullanici = new Kullanici();


        }
        public void Add(Kullanici table)
        {
            db.kullanicilar.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            Kullanici = db.kullanicilar.Find(Id);
            db.kullanicilar.Remove(Kullanici);
            db.SaveChanges();
        }

        public void Edit(int Id, Kullanici table)
        {
            db = new MyDBContext();
            db.kullanicilar.Update(table);
            db.SaveChanges();
        }

        public Kullanici Find(int Id)
        {
            return db.kullanicilar.Where(s => s.id == Id).FirstOrDefault();
        }

        public List<Kullanici> getAllData()
        {
            return db.kullanicilar.ToList();
        }

        public List<Kullanici> getDataByUser(string UserId)
        {
            return db.kullanicilar.Where(s => s.UserId == UserId).ToList();
        }

        public List<Kullanici> search(string searchItem)
        {
            return db.kullanicilar.Where(x => 
            x.Adı.Contains(searchItem)||
            x.SoyAdı.Contains(searchItem)||
            x.Email.Contains(searchItem)||
            x.Telefon.Contains(searchItem)
            ).ToList();
        }
    }
}
