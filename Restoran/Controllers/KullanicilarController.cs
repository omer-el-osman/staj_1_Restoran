using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;

namespace Restoran.Controllers
{
    public class KullanicilarController : Controller
    {

        private readonly Ihelper<Kullanici> ihelper;
        private Kullanici Kullanici;
        private int PageItme;

        public KullanicilarController(Ihelper<Kullanici> ihelper)
        {
            this.ihelper = ihelper;
            Kullanici = new Kullanici();
            PageItme = 6;

        }
        // GET: KullanicilarController
        public ActionResult Index(int? id)
        {

            if (id == 0 || id == null)
            {
                //take birinci elemanleri almak icin burada ilk 5 eleman aldik
                return View(ihelper.getAllData().Take(PageItme));
            }
            else
            {
                var data = ihelper.getAllData().Where(x => x.id > id).Take(PageItme);
                return View(data);
            }
        }



        // GET: KullanicilarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KullanicilarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KullanicilarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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



        public ActionResult search(string searchItem)
        {
            if (searchItem == null)
            {
                return View("Index", ihelper.getAllData());

            }
            else
            {
                return View("Index", ihelper.search(searchItem));

            }
        }



        // GET: KullanicilarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KullanicilarController/Edit/5
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

        // GET: KullanicilarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KullanicilarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
