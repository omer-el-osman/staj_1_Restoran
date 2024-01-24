using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyData
{
    public interface Ihelper<Table>
    {
        //read
        List<Table> getAllData();
        List<Table> getDataByUser(string UserId);
        List<Table> search(string searchItem);
        Table Find(int Id);



        //write

        void Add(Table table);
        void Edit(int Id, Table table);
        void delete(int Id);
    }
}
