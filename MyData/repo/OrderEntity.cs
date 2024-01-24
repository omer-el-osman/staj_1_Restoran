using MyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData.repo
{
    public class OrderEntity : Ihelper<Order>
    {
        private MyDBContext db;
        private Order order;
        public OrderEntity()
        {
            db = new MyDBContext();
            order = new Order();
        }
        public void Add(Order table)
        {
            db.orders.Add(table);
            db.SaveChanges();
        }

        public void delete(int Id)
        {
            order = db.orders.Find(Id);
            db.orders.Remove(order);
            db.SaveChanges();
        }

        public void Edit(int Id, Order table)
        {
            db = new MyDBContext();
            db.orders.Update(table);
            db.SaveChanges();
        }

        public Order Find(int Id)
        {
            return db.orders.Where(s => s.id == Id).FirstOrDefault();
        }

        public List<Order> getAllData()
        {
            return db.orders.ToList();
        }

        public List<Order> getDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Order> search(string searchItem)
        {
            throw new NotImplementedException();
        }
    }
}
