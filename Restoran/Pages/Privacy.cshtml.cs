using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyClasses;
using MyData;

namespace Restoran.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly Ihelper<MyClasses.Order> ihelper;
        public List<MyClasses.Order> order = new List<MyClasses.Order>();
        public PrivacyModel(ILogger<PrivacyModel> logger,Ihelper<MyClasses.Order> ihelper)
        {
            _logger = logger;
            this.ihelper = ihelper;
        }

        public void OnGet()
        {
            order= ihelper.getAllData().ToList();
        }
    }
}