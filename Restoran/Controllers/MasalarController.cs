using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;

namespace Restoran.Controllers
{
    public class MasalarController : Controller
    {
        private readonly Ihelper<Masalar> ihelper;
        private Masalar Masalar;
        private int PageItme;
        public MasalarController(Ihelper<Masalar> ihelper)
        {
            this.ihelper = ihelper;
            Masalar = new Masalar();
            PageItme = 6;

        }
        // GET: MasalarController
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

        // GET: MasalarController/Details/5
        public ActionResult Details(int id)
        {
            Masalar = ihelper.Find(id);
            return View(Masalar);
        }

        // GET: MasalarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasalarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Masalar collection)
        {
            try
            {
                ihelper.Add(collection);
                TempData["messaj"] = "Başarıyla Eklendi";
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






        // GET: MasalarController/Edit/5
        public ActionResult Edit(int id)
        {
            Masalar = ihelper.Find(id);
            return View(Masalar);
        }

        // POST: MasalarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Masalar collection)
        {
            try
            {
                ihelper.Edit(id, collection);
                TempData["messaj"] = "Başarıyla değiştirildi";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasalarController/Delete/5
        public ActionResult Delete(int id)
        {
            Masalar = ihelper.Find(id);
            return View(Masalar);
        }

        // POST: MasalarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {


                ihelper.delete(id);

                TempData["messaj"] = "Başarıyla Silindi";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
