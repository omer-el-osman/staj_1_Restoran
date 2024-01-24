using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;
using MyData;
namespace MyData.repo
{
    public class yemekMenusuEntity : Ihelper<yemekMenusu>
    {
        private MyDBContext db;
        private yemekMenusu yemekMenusu;
        public yemekMenusuEntity()
        {
            db = new MyDBContext();
            yemekMenusu = new yemekMenusu();

        }
        public void Add(yemekMenusu table)
        {
            db.yemekMenusus.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            yemekMenusu = db.yemekMenusus.Find(Id);
            db.yemekMenusus.Remove(yemekMenusu);
            db.SaveChanges();
        }

        public void Edit(int Id, yemekMenusu table)
        {
            db = new MyDBContext();
            db.yemekMenusus.Update(table);
            db.SaveChanges();
        }

        public yemekMenusu Find(int Id)
        {
            return db.yemekMenusus.Where(u => u.id == Id).FirstOrDefault();
        }

        public List<yemekMenusu> getAllData()
        {
            return db.yemekMenusus.ToList();
        }

        public List<yemekMenusu> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<yemekMenusu> search(string searchItem)
        {
            return db.yemekMenusus.Where(x =>
            x.id.ToString().Contains(searchItem)||
            x.Yemek_Adi.Contains(searchItem) ||
            x.fiyat.ToString().Contains(searchItem) ||
            x.Yemek_Kategorisi.Contains(searchItem) 
            ).ToList();
        }
    }
}
