using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
          return View();
      }

      [HttpGet("/clients")]
        public ActionResult Clients()
        {
            return View("Clients", Client.GetAll());
        }

        [HttpGet("/stylists")]
        public ActionResult Stylists()
        {
            return View("Stylists", Stylist.GetAll());
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
          return View();
        }

        [HttpPost("/stylists")]
        public ActionResult NewStylist()
        {
            Stylist newStylist = new Stylist(Request.Form["firstName"], Request.Form["lastName"]);
            newStylist.Save();
            return View("Stylists", Stylist.GetAll());
        }

        [HttpGet("/stylists/clear")]
        public ActionResult Clear()
        {
          Stylist.Clear();
          return View("Stylists", Stylist.GetAll());
        }
    }
}
