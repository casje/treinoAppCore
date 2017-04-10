using Microsoft.AspNetCore.Mvc;

namespace treinoAppCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public string Test(int? ident)
        {
            return string.Format("Valor do parametro Ident: {0}", ident);
        }
        
    }
}