using MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.repo
{
    public class ReservasyonEntity:Ihelper<Reservasyon>
    {
         private MyDBContext db;
        private Reservasyon Reservasyon;
        public ReservasyonEntity()
        {
            db = new MyDBContext();
            Reservasyon = new Reservasyon();
        }
        public void Add(Reservasyon table)
        {
            db.reservasyons.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            Reservasyon = db.reservasyons.Find(Id);
            db.reservasyons.Remove(Reservasyon);
            db.SaveChanges();
        }

        public void Edit(int Id, Reservasyon table)
        {
            db = new MyDBContext();
            db.reservasyons.Update(table);
            db.SaveChanges();
        }

        public Reservasyon Find(int Id)
        {
            return db.reservasyons.Where(t => t.id == Id).FirstOrDefault();
        }

        public List<Reservasyon> getAllData()
        {
            return db.reservasyons.ToList();
        }

        public List<Reservasyon> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Reservasyon> search(string searchItem)
        {
            return db.reservasyons.Where(x =>
            x.Adı.Contains(searchItem) ||
            x.Email.Contains(searchItem) ||
            x.Masa_num.ToString().Contains(searchItem) ||
            x.SoyAdı.Contains(searchItem) ||
            x.tarih.Contains(searchItem) ||
            x.Telefon.Contains(searchItem) ||
            x.Durum.Contains(searchItem) 
            ).ToList();
        }
    }
}
