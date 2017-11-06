using System.Linq;
using System.Web.Mvc;
using HottWebApp.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace HottWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.UserName = GetUserName();

            return View();
        }

        public ActionResult PlayBill()
        {
            ViewBag.Message = "Успей выбрать билет по выгодной цене!";
            ViewBag.UserName = GetUserName();

            return View(new PlayBillModel(GetEvents()));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Вы можете связаться с нами любым удобным для Вас способом.";
            ViewBag.UserName = GetUserName();

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

        private Event[] GetEvents()
        {
            using (var context = new HottEntities())
            {
                return context.Events.Include(e => e.EventType).Include(e => e.Hall).Include(e=>e.Hall.Building).ToArray();
            }
        }
    }
}