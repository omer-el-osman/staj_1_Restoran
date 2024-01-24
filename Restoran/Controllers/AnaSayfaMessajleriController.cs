using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;
namespace Restoran.Controllers
{
    public class AnaSayfaMessajleriController : Controller
    {

        private readonly Ihelper<AnaSayfaMessajleri> ihelper;
        private readonly IWebHostEnvironment webHost;
        private AnaSayfaMessajleri messajleri;
        private int PageItme;
        public AnaSayfaMessajleriController(Ihelper<AnaSayfaMessajleri> ihelper, IWebHostEnvironment webHost)
        {
            this.ihelper = ihelper;
            this.webHost = webHost;
            messajleri = new AnaSayfaMessajleri();
            PageItme = 6;
        }
        // GET: AnaSayfaMessajleriController
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

        // GET: AnaSayfaMessajleriController/Details/5
        public ActionResult Details(int id)
        {
            messajleri = ihelper.Find(id);

            return View(messajleri);
        }

        // GET: AnaSayfaMessajleriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnaSayfaMessajleriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.AnaSayfaMessajleri collection)
        {
            try
            {
                var imageName = string.Empty;
                if (collection.Resim != null)
                {

                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\AnaSayfaMessajleri");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    AnaSayfaMessajleri AnaSayfaMessajleri = new AnaSayfaMessajleri()
                    {
                        id = collection.id,
                        Adi = collection.Adi,
                        Messaj = collection.Messaj,
                        Resim = imageName
                    };

                    ihelper.Add(AnaSayfaMessajleri);
                    TempData["messaj"] = "Başarıyla Eklendi";
                }
                else
                {
                    AnaSayfaMessajleri AnaSayfaMessajleri = new AnaSayfaMessajleri()
                    {
                        id = collection.id,
                        Adi = collection.Adi,
                        Messaj = collection.Messaj,
                        Resim = messajleri.Resim
                    };

                    ihelper.Add(AnaSayfaMessajleri);
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



        // GET: AnaSayfaMessajleriController/Edit/5
        public ActionResult Edit(int id)
        {

            messajleri = ihelper.Find(id);

            return View(messajleri);
        }

        // POST: AnaSayfaMessajleriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModels.AnaSayfaMessajleri collection)
        {
            try
            {
                var imageName = string.Empty;
                if (collection.Resim != null)
                {

                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\AnaSayfaMessajleri");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    AnaSayfaMessajleri AnaSayfaMessajleri = new AnaSayfaMessajleri()
                    {
                        id = collection.id,
                        Adi = collection.Adi,
                        Messaj = collection.Messaj,
                        Resim = imageName
                    };

                    ihelper.Edit(id, AnaSayfaMessajleri);
                    TempData["messaj"] = "Başarıyla değiştirildi";
                }
                else
                {
                     messajleri = ihelper.Find(id);

                    messajleri.id = collection.id;
                    messajleri.Adi = collection.Adi;
                    messajleri.Messaj = collection.Messaj;
                    messajleri.Resim = messajleri.Resim;
                    

                    ihelper.Edit(id,messajleri);
                    TempData["messaj"] = "Başarıyla değiştirildi";

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnaSayfaMessajleriController/Delete/5
        public ActionResult Delete(int id)
        {

            messajleri = ihelper.Find(id);

            return View(messajleri);
        }

        // POST: AnaSayfaMessajleriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
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
