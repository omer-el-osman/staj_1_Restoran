using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;

namespace Restoran.Controllers
{
    public class yemekKatigorisiController : Controller
    {
        private readonly Ihelper<yemekKatigorisi> ihelper;
        private yemekKatigorisi yemekKatigorisi;
        private int PageItme;
        public yemekKatigorisiController(Ihelper<yemekKatigorisi> ihelper)
        {
            this.ihelper = ihelper;
            yemekKatigorisi = new yemekKatigorisi();
            PageItme = 6;

        }
        // GET: yemekKatigorisiController
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

        // GET: yemekKatigorisiController/Details/5
        public ActionResult Details(int id)
        {
            yemekKatigorisi = ihelper.Find(id);
            return View(yemekKatigorisi);
        }

        // GET: yemekKatigorisiController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: yemekKatigorisiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(yemekKatigorisi collection)
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






        // GET: yemekKatigorisiController/Edit/5
        public ActionResult Edit(int id)
        {
            yemekKatigorisi = ihelper.Find(id);
            return View(yemekKatigorisi);
        }

        // POST: yemekKatigorisiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, yemekKatigorisi collection)
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

        // GET: yemekKatigorisiController/Delete/5
        public ActionResult Delete(int id)
        {
            yemekKatigorisi = ihelper.Find(id);
            return View(yemekKatigorisi);
        }

        // POST: yemekKatigorisiController/Delete/5
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
