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

        [HttpPost("/clients")]
        public ActionResult SortClients()
        {
            Client.SetSortCondition(Request.Form["button"]);
            return View("Clients", Client.Sort());
        }

        [HttpGet("/stylists")]
        public ActionResult Stylists()
        {
            return View("Stylists", Stylist.GetAll());
        }

        [HttpPost("/stylists")]
        public ActionResult SortStylists()
        {
            Stylist.SetSortCondition(Request.Form["button"]);
            return View("Stylists", Stylist.Sort());
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Detail(string id)
        {
            return View("Detail", Client.Find(id));
        }
    }
}
