using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using MyClasses;
using MyData;
using Microsoft.AspNetCore.Authorization;

namespace Restoran.Controllers
{
    public class EmailMassejController : Controller
    {
        private readonly Ihelper<Reservasyon> ihelper;
        private readonly IWebHostEnvironment webHost;
        private Reservasyon Reservasyon;
        private int PageItme;
        public EmailMassejController(Ihelper<Reservasyon> ihelper, IWebHostEnvironment webHost)
        {
            this.ihelper = ihelper;
            this.webHost = webHost;
            Reservasyon = new Reservasyon();
            PageItme = 6;
        }
        //public IActionResult Index()
        //{

        //    return RedirectToPage("/Index");
        //}
        public ActionResult Index1(int? id)
        {

           // if (id == 0 || id == null)
           // {
           //     //take birinci elemanleri almak icin burada ilk 5 eleman aldik
           //     return View(ihelper.getAllData().Take(PageItme));
           // }
           //else if (id == 10)
           // {
                return View(ihelper.getAllData());

            //}
            //else
            //{
            //    var data = ihelper.getAllData().Where(x => x.id > id).Take(PageItme);
            //    return View(data);
            //}
        }
      
        [HttpPost]
        public IActionResult Index(string Adi, string SoyAdi, string Email, string tel, string SubeAdi, int masa_num, string tarih)
        {
            Reservasyon.Adı = Adi;
            Reservasyon.SoyAdı = SoyAdi;
            Reservasyon.Email = Email;
            Reservasyon.Telefon = tel;
            Reservasyon.SubeAdi = SubeAdi;
            Reservasyon.Masa_num = masa_num;
            Reservasyon.tarih = tarih;
            Reservasyon.Durum = "Bekleme";
            ihelper.Add(Reservasyon);
            
            var mail = "tmr200677@gmail.com";
            var pass = "mltrnptrsoeihhcm";
            var mess = new MailMessage();
            mess.From = new MailAddress(Email);
            //mess.Subject = sub;
            mess.To.Add(mail);
            mess.Body = $"<html><Body>" +
                $"<h2>Adi : {Adi}</h2><br>" +
                $"<h2>SoyAdi : {SoyAdi}</h2><br>" +
                $"<h2>Email : {Email}</h2><br>" +
                $"<h2>Tel :{tel}</h2><br>" +
                $"<h2>Tel :{SubeAdi}</h2><br>" +
                $"<h2>Masa : {masa_num}</h2><br>" +
                $"<h2>Tarih : {tarih}</h2><br>" +
                $"</Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);

          



            //TempData["messaj"] = "başarıyla gönderildi";
            return RedirectToPage("/Index");
        }


        public ActionResult search(string searchItem)
        {
            if (searchItem == null)
            {
                return View("Index1", ihelper.getAllData());

            }
            else
            {
                return View("Index1", ihelper.search(searchItem));

            }
        }



        [HttpPost]
        public IActionResult Onaylama(int id)
        {
            Reservasyon = ihelper.Find(id);

            Reservasyon.Durum = "Onaylandi";
            ihelper.Edit(id,Reservasyon);
            TempData["messaj"] = "Başarıyla Onaylandi";

            var mail = "tmr200677@gmail.com";
            var pass = "mltrnptrsoeihhcm";
            var mess = new MailMessage();
            mess.From = new MailAddress(mail);
           
            mess.To.Add(Reservasyon.Email);
            mess.Body = $"<html><Body>Basariyla Masa Aldiniz Bu Tarih te {Reservasyon.tarih} sizi Bekliyoriz</Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);


            return RedirectToAction(nameof(Index1));
        }


            [HttpPost]
        public IActionResult Reddetme(int id)
        {
            Reservasyon = ihelper.Find(id);

            Reservasyon.Durum = "Reddetme";
            ihelper.Edit(id, Reservasyon);
            TempData["messaj"] = "Başarıyla  REddedildi";

            var mail = "tmr200677@gmail.com";
            var pass = "mltrnptrsoeihhcm";
            var mess = new MailMessage();
            mess.From = new MailAddress(mail);

            mess.To.Add(Reservasyon.Email);
            mess.Body = $"<html><Body>suan bu masa bos degildir lutfen baska bir masayi yeniden secin saygiyla</Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);


            
            return RedirectToAction(nameof(Index1));
        }
        
        [HttpPost]
        public IActionResult Iptal_Et(int id)
        {
            Reservasyon = ihelper.Find(id);

            Reservasyon.Durum = "Iptal Edildi";
            ihelper.Edit(id, Reservasyon);
          

            var mail = "tmr200677@gmail.com";
            var pass = "mltrnptrsoeihhcm";
            var mess = new MailMessage();
            mess.From = new MailAddress(mail);

            mess.To.Add(Reservasyon.Email);
            mess.Body = $"<html><Body>Basariyla talebinizi Iptal Edildi </Body></html>";
            mess.IsBodyHtml = true;

            var smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);

            mail = "tmr200677@gmail.com";
            pass = "mltrnptrsoeihhcm";
            mess = new MailMessage();
            mess.From = new MailAddress(Reservasyon.Email);
            //mess.Subject = sub;
            mess.To.Add(mail);
            mess.Body = $"<html>Sayin{Reservasyon.Adı +" "+Reservasyon.SoyAdı} bu masanin numrasi {Reservasyon.Masa_num} ve bu subede {Reservasyon.SubeAdi} icin reservasyon yapti ama suan iptal edildi</html>";
            mess.IsBodyHtml = true;

             smt = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,

                Credentials = new NetworkCredential(mail, pass),

                EnableSsl = true


            };

            smt.Send(mess);



            return RedirectToAction(nameof(Index1));
        }


    }
}
