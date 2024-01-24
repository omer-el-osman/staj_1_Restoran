using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;

namespace Restoran.Controllers
{
    public class SubelerController : Controller
    {
        private readonly Ihelper<Subeler> ihelper;
        private readonly IWebHostEnvironment webHost;
        private Subeler Subeler;
        private int PageItme;
        public SubelerController(Ihelper<Subeler> ihelper, IWebHostEnvironment webHost)
        {
            this.ihelper = ihelper;
            this.webHost = webHost;
            Subeler = new Subeler();
            PageItme = 6;
        }
        // GET: SubelerController
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

        // GET: SubelerController/Details/5
        public ActionResult Details(int id)
        {
            Subeler = ihelper.Find(id);
            return View(Subeler);
        }

        // GET: SubelerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubelerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Subeler collection)
        {
            try
            {
                var imageName = string.Empty;
                if (collection.Resim != null)
                {
                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\Subeler");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    Subeler subeler = new Subeler()
                    {
                        id = collection.id,
                        SubeAdi = collection.SubeAdi,
                        About = collection.About,
                        Resim = imageName,
                        masalar=collection.masalar
                    };
                    ihelper.Add(subeler);
                    TempData["messaj"] = "Başarıyla Eklendi";
                }
                else
                {
                    Subeler subeler = new Subeler()
                    {
                        id = collection.id,
                        SubeAdi = collection.SubeAdi,
                        About = collection.About,
                        masalar = collection.masalar,

                    Resim = Subeler.Resim
                    };

                    ihelper.Add(subeler);
                    TempData["messaj"] = "Başarıyla Eklendi";
                }



           
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





        // GET: SubelerController/Edit/5
        public ActionResult Edit(int id)
        {
            Subeler = ihelper.Find(id);
            return View(Subeler);
        }

        // POST: SubelerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModels.Subeler collection)
        {
            try
            {
                var imageName = string.Empty;
                if (collection.Resim != null)
                {
                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\Subeler");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    Subeler subeler = new Subeler()
                    {
                        id = collection.id,
                        SubeAdi = collection.SubeAdi,
                        About = collection.About,
                        masalar = collection.masalar,
                    Resim = imageName
                    };

                    ihelper.Edit(id, subeler);
                    TempData["messaj"] = "Başarıyla değiştirildi";
                }
                else
                {
                    Subeler = ihelper.Find(id);
                    Subeler.id = collection.id;
                    Subeler.SubeAdi = collection.SubeAdi;
                    Subeler.About = collection.About;
                    Subeler.Resim = Subeler.Resim;
                    Subeler.masalar = collection.masalar;
                    ihelper.Edit(id, Subeler);
                    TempData["messaj"] = "Başarıyla değiştirildi";
                }



               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubelerController/Delete/5
        public ActionResult Delete(int id)
        {
            Subeler = ihelper.Find(id);
            return View(Subeler);
        }

        // POST: SubelerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Subeler collection)
        {
            try
            {
                 //Subeler = ihelper.Find(id);

                ihelper.delete(id);
                //var rootpath = Path.Combine(webHost.WebRootPath, "images\\Subeler");
                //var imageName = Subeler.Resim;
                //var imagePath = Path.Combine(rootpath, imageName);
                //if (System.IO.File.Exists(imagePath))
                //{
                //    System.IO.File.Delete(imagePath);
                //}
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
