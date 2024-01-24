using MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.repo
{
    public class MasalarEntity:Ihelper<Masalar>
    {
        private MyDBContext db;
        private Masalar masalar;
        public MasalarEntity()
        {
            db = new MyDBContext();
            masalar = new Masalar();
        }
        public void Add(Masalar table)
        {
            db.masalars.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            masalar = db.masalars.Find(Id);
            db.masalars.Remove(masalar);
            db.SaveChanges();
        }

        public void Edit(int Id, Masalar table)
        {
            db = new MyDBContext();
            db.masalars.Update(table);
            db.SaveChanges();
        }

        public Masalar Find(int Id)
        {
            return db.masalars.Where(s => s.id == Id).FirstOrDefault();
        }

        public List<Masalar> getAllData()
        {
            return db.masalars.ToList();
        }

        public List<Masalar> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Masalar> search(string searchItem)
        {
            return db.masalars.Where(r =>
            r.SubeAdi.Contains(searchItem) ||
           r.masalar.ToString().Contains(searchItem)
            ).ToList();
        }
    }
}
