using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClasses;
using MyData;

namespace MyData.repo
{
	public class yemekKatigorisiEntity : Ihelper<yemekKatigorisi>
	{
		private MyDBContext db;
		private yemekKatigorisi yemekKatigorisi;
		public yemekKatigorisiEntity()
		{
			db = new MyDBContext();
			yemekKatigorisi = new yemekKatigorisi();
		}
		public void Add(yemekKatigorisi table)
		{
			db.yemekKatigorisis.Add(table);
			db.SaveChanges();
		}

		public void delete(int Id)
		{
			yemekKatigorisi = db.yemekKatigorisis.Find(Id);
			db.yemekKatigorisis.Remove(yemekKatigorisi);
			db.SaveChanges();
		}

		public void Edit(int Id, yemekKatigorisi table)
		{
			db = new MyDBContext();
			db.yemekKatigorisis.Update(table);
			db.SaveChanges();
		}

		public yemekKatigorisi Find(int Id)
		{
			return db.yemekKatigorisis.Where(s => s.id == Id).FirstOrDefault();
		}

		public List<yemekKatigorisi> getAllData()
		{
			return db.yemekKatigorisis.ToList();
		}

		public List<yemekKatigorisi> getDataByUser(string UserId)
		{
			throw new NotImplementedException();
		}

		public List<yemekKatigorisi> search(string searchItem)
		{
			return db.yemekKatigorisis.Where(s => s.Katigori.Contains(searchItem)).ToList();
		}
	}
}
