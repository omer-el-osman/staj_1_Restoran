using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;
using MyData;
namespace MyData.repo
{
    public class AnaSayfaMessajleriEntity : Ihelper<AnaSayfaMessajleri>
    {
        private MyDBContext db;
        private AnaSayfaMessajleri anaSayfaMessajleri;
        public AnaSayfaMessajleriEntity()
        {
            db = new MyDBContext();
            anaSayfaMessajleri = new AnaSayfaMessajleri();
        }
        public void Add(AnaSayfaMessajleri table)
        {
            db.anaSayfaMessajleris.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            anaSayfaMessajleri = db.anaSayfaMessajleris.Find(Id);
            db.anaSayfaMessajleris.Remove(anaSayfaMessajleri);
            db.SaveChanges();
        }

        public void Edit(int Id, AnaSayfaMessajleri table)
        {
            db = new MyDBContext();
            db.anaSayfaMessajleris.Update(table);
            db.SaveChanges();
        }

        public AnaSayfaMessajleri Find(int Id)
        {
            return db.anaSayfaMessajleris.Where(t => t.id == Id).FirstOrDefault();
        }

        public List<AnaSayfaMessajleri> getAllData()
        {
            return db.anaSayfaMessajleris.ToList();
        }

        public List<AnaSayfaMessajleri> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<AnaSayfaMessajleri> search(string searchItem)
        {
            return db.anaSayfaMessajleris.Where(x =>
            x.Adi.Contains(searchItem) ||
            x.Messaj.Contains(searchItem) 
            ).ToList();
        }
    }
}
