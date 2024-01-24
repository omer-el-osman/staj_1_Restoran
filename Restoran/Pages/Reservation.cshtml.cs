using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyData;

namespace Restoran.Pages
{
   
    public class ReservationModel : PageModel
    {
        public object id { get; set; }
        public List<MyClasses.Subeler> Sube = new List<MyClasses.Subeler>();
        public List<MyClasses.Reservasyon> Reser = new List<MyClasses.Reservasyon>();


        private readonly Ihelper<MyClasses.Subeler> ihelper;
        private readonly Ihelper<MyClasses.Reservasyon> ihelper1;
        public MyClasses.Subeler subelers;
        //public MyClasses.Masalar masa;

        readonly IndexModel? indexModel;
    
        public ReservationModel(Ihelper<MyClasses.Subeler> ihelper,Ihelper<MyClasses.Reservasyon> ihelper1)
        {
            this.ihelper = ihelper;
            this.ihelper1 = ihelper1;
        }
        public List<int> ints { get; set; }
        public void OnGet()
        {
          
            Sube = ihelper.getAllData().ToList();
            id = HttpContext.Request.RouteValues["id"];
            subelers = ihelper.Find(Convert.ToInt32(id));
            Reser = ihelper1.getAllData().ToList();
         

        }
        public void Mychecked()
        {
           
        }
    }
}
