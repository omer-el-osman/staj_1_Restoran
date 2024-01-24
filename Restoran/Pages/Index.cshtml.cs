using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using MyClasses;
using MyData;
using System.Collections.Generic;
//using MyData.Migrations;

namespace Restoran.Pages
{
   

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Ihelper<MyClasses.yemekKatigorisi> ihelper;
        private readonly Ihelper<MyClasses.yemekMenusu> ihelper2;
      
        public IndexModel(ILogger<IndexModel> logger
            ,Ihelper<MyClasses.yemekKatigorisi> ihelper
            , Ihelper<MyClasses.yemekMenusu> ihelper2)
        {
            _logger = logger;
            this.ihelper = ihelper;
            this.ihelper2 = ihelper2;
           
        }
        public  List<MyClasses.yemekKatigorisi> Mykatigori = new List<MyClasses.yemekKatigorisi>();
        public  List<MyClasses.yemekMenusu> MyYemek = new List<MyClasses.yemekMenusu>();
       
        public void OnGet(string state,string search)
        {
           
                
            
            AllKatigori();
            AllYemek();
            if (state== "ByKatigori")
            {
                ByKatigori(search);
            }
            else if(state=="all"){
                AllYemek();
            }

        }

        public void ByKatigori(string name)
        {
            MyYemek = ihelper2.getAllData().Where(x => x.Yemek_Kategorisi == name).ToList();
        }
        public void AllYemek()
        {
            MyYemek = ihelper2.getAllData().ToList();
        }
        public void AllKatigori()
        {
            Mykatigori = ihelper.getAllData().ToList();
        }
    }
}