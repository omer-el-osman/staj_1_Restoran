using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyClasses;
using MyData;

namespace Restoran.Controllers
{
    public class yemekMenusuController : Controller
    {
        private readonly Ihelper<yemekMenusu> ihelper;
        private readonly IWebHostEnvironment webHost;
        private yemekMenusu yemekMenusu;
        private int PageItme;
        public List<int> MyYemekIdisi = new List<int>();
        public yemekMenusuController(Ihelper<yemekMenusu> ihelper, IWebHostEnvironment webHost)
        {
            this.ihelper = ihelper;
            this.webHost = webHost;
            yemekMenusu = new yemekMenusu();
            PageItme = 6;
        }


        // GET: yemekMenusuController
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

        // GET: yemekMenusuController/Details/5
        public ActionResult Details(int id)
        {
            yemekMenusu = ihelper.Find(id);
            return View(yemekMenusu);
        }
        

        // GET: yemekMenusuController/Create
        public ActionResult Create()
        {
            return View();
        }
      
        // POST: yemekMenusuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.yemekMenusu collection)
        {
          
            try
            {

                var imageName = string.Empty;
                if (collection.Resim != null)
                {

                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\YemekMenu");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    yemekMenusu yemekMenusu = new yemekMenusu()
                    {
                        id = collection.id,
                        Yemek_Kategorisi=collection.Yemek_Kategorisi,
                        Yemek_Adi = collection.Yemek_Adi,
                        fiyat = collection.fiyat,
                        Resim = imageName
                    };

                    ihelper.Add(yemekMenusu);
                    TempData["messaj"] = "Başarıyla Eklendi";
                }
                else
                {
                    yemekMenusu yemekMenusu2 = new yemekMenusu()
                    {
                        id = collection.id,
                        Yemek_Kategorisi=collection.Yemek_Kategorisi,
                        Yemek_Adi = collection.Yemek_Adi,
                        fiyat = collection.fiyat,
                        Resim = yemekMenusu.Resim
                    };
                   
                    ihelper.Add(yemekMenusu2);
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
     

        // GET: yemekMenusuController/Edit/5
        public ActionResult Edit(int id)
        {
            yemekMenusu = ihelper.Find(id);
            return View(yemekMenusu);

        }

        // POST: yemekMenusuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewModels.yemekMenusu collection)
        {
            try
            {
                var imageName = string.Empty;
                if (collection.Resim != null)
                {

                    var rootpath = Path.Combine(webHost.WebRootPath, "images\\YemekMenu");
                    imageName = Guid.NewGuid() + "-" + collection.Resim.FileName;
                    var imagePath = Path.Combine(rootpath, imageName);
                    collection.Resim.CopyTo(new FileStream(imagePath, FileMode.Create));

                    yemekMenusu yemekMenusu2 = new yemekMenusu()
                    {
                        id = collection.id,
                        Yemek_Kategorisi = collection.Yemek_Kategorisi,
                        Yemek_Adi = collection.Yemek_Adi,
                        fiyat = collection.fiyat,
                        Resim = imageName
                    };

                    ihelper.Edit(id, yemekMenusu2);
                    TempData["messaj"] = "Başarıyla değiştirildi";
                }
                else
                {
                    //yemekMenusu = ihelper.Find(id);
                    //yemekMenusu.id = collection.id;
                    //yemekMenusu.Yemek_Adi = collection.Yemek_Adi;
                    //yemekMenusu.Resim = yemekMenusu.Resim;
                    //yemekMenusu.Yemek_Kategorisi = collection.Yemek_Kategorisi;
                    //yemekMenusu.fiyat = collection.fiyat;

                    yemekMenusu = ihelper.Find(id);
                    yemekMenusu.id =yemekMenusu.id;
                    yemekMenusu.Yemek_Adi = yemekMenusu.Yemek_Adi;
                    yemekMenusu.Resim = yemekMenusu.Resim;
                    yemekMenusu.Yemek_Kategorisi = yemekMenusu.Yemek_Kategorisi;
                    yemekMenusu.fiyat =1555;
                    ihelper.Edit(id, yemekMenusu);
                    TempData["messaj"] = "Başarıyla değiştirildi";
                }

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: yemekMenusuController/Delete/5
        public ActionResult Delete(int id)
        {

            yemekMenusu = ihelper.Find(id);
            return View(yemekMenusu);
        }

        // POST: yemekMenusuController/Delete/5
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
