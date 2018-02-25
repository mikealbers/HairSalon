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
        public ActionResult StylistsCreateForm()
        {
          return View();
        }

        [HttpGet("/clients/new")]
        public ActionResult ClientsCreateForm()
        {
          return View(Stylist.GetAll());
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
          return View("Index", Stylist.GetAll());
        }

        [HttpPost("/stylists/sort")]
        public ActionResult Sort()
        {
          Stylist.SetSortCondition(Request.Form["button"]);
          Stylist.Sort();
          return View("Stylists", Stylist.Sort());
        }
    }
}
