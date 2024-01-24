using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;
using System.Net.NetworkInformation;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Restoran.Controllers
{
    public class OrderController : Controller
    {
        private readonly Ihelper<yemekMenusu> ihelperyemekMenusu;
        private readonly IWebHostEnvironment webHost;
        private readonly Ihelper<Order> ihelperOrder;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserStore<IdentityUser> userStore;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly Ihelper<Kullanici> ihelperkullaici;
        private yemekMenusu yemekMenusu;
        private Order order;
        private int PageItme;
        public List<int> MyYemekIdisi = new List<int>();
        public OrderController(Ihelper<yemekMenusu> ihelperyemekMenusu,
            IWebHostEnvironment webHost,
            Ihelper<Order> ihelperOrder,
             UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            Ihelper<Kullanici> ihelperkullaici
            )
        {
            this.ihelperyemekMenusu = ihelperyemekMenusu;
            this.webHost = webHost;
            this.ihelperOrder = ihelperOrder;
            this.userManager = userManager;
            this.userStore = userStore;
            this.signInManager = signInManager;
            this.ihelperkullaici = ihelperkullaici;
            yemekMenusu = new yemekMenusu();
            order = new Order();
            PageItme = 6;
           
        }
        public  ActionResult Index(int? id)
        {

            if (id == 0 || id == null)
            {
                //take birinci elemanleri almak icin burada ilk 5 eleman aldik
                 return  View(ihelperOrder.getAllData().Take(PageItme));

            }
            else
            {
                var data = ihelperOrder.getAllData().Where(x => x.id > id).Take(PageItme);
                  return View(data);

            }
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return RedirectToPage("/Index");
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, IFormCollection collection)
        {
            try
            {
                string TelimKodu = Guid.NewGuid().ToString().Substring(0,5);
                foreach (var c in ihelperkullaici.getAllData())
                {

                    if (c.Email == User.Identity?.Name! )
                    {


                        order.Adı = c.Adı;
                        order.SoyAdı = c.SoyAdı;
                        order.Telefon = c.Telefon;
                        order.Email = c.Email;
                        order.UserId = c.UserId;


                    }
                }
                yemekMenusu = ihelperyemekMenusu.Find(id);
                
                    order.Yemek_Adi = yemekMenusu.Yemek_Adi;
                    order.Yemek_Kategorisi = yemekMenusu.Yemek_Kategorisi;
                    order.fiyat = yemekMenusu.fiyat;
                    order.Resim = yemekMenusu.Resim;
                    order.Check = true;
                    order.durum = "Bekleme";
                order.Teslim_Kodu = TelimKodu;
                ihelperOrder.Add(order);
                return RedirectToPage("/Index");
            }
            catch
            {

                return RedirectToPage("/Index");

            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToPage("/Privacy");

        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                ihelperOrder.delete(id);
                return RedirectToPage("/Privacy");
            }
            catch
            {
                return RedirectToPage("/Privacy");
            }
        }
    }
}
