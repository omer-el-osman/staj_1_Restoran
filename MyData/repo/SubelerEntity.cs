using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;
using MyData;
namespace MyData.repo
{
    public class SubelerEntity : Ihelper<Subeler>
    {
        private MyDBContext db;
        private Subeler subeler;
        public SubelerEntity()
        {
            db = new MyDBContext();
            subeler = new Subeler();
        }
        public void Add(Subeler table)
        {
            db.subelers.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            subeler = db.subelers.Find(Id);
            db.subelers.Remove(subeler);
            db.SaveChanges();
        }

        public void Edit(int Id, Subeler table)
        {
            db = new MyDBContext();
            db.subelers.Update(table);
            db.SaveChanges();
        }

        public Subeler Find(int Id)
        {
            return db.subelers.Where(s => s.id == Id).FirstOrDefault();
        }

        public List<Subeler> getAllData()
        {
            return db.subelers.ToList();
        }

        public List<Subeler> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Subeler> search(string searchItem)
        {
            return db.subelers.Where(r =>
            r.SubeAdi.Contains(searchItem) ||
            r.About.Contains(searchItem)
            ).ToList();
        }
    }
}
