using Microsoft.AspNetCore.Mvc;

namespace treinoAppCore.Controllers
{
    [Route("app/admin")]
    public class AdminController : Controller
    {
        [Route("start")]
        public object Index()
        {
            var identify = new {Ident = 18, Name = "Claudio", Email = "claudio@gmail.com", Token = "AS877CN3248278"};
            
            return identify;
        }
        
    }
}