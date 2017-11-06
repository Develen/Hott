using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace HottWebApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = GetUserName();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Успей выбрать билет по выгодной цене!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Вы можете связаться с нами любым удобным для Вас способом.";

            return View();
        }

        private string GetUserName()
        {
            var identityUserName = User.Identity.GetUserName();
            using (var context = new HottEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == identityUserName);
                if (user != null)
                {
                    return $"{user.Name} {user.Sername}";
                }
            }
            return identityUserName;
        }
    }
}