using Microsoft.AspNetCore.Mvc;
using WorldData.Models;

namespace HairSalon
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
          return View();
      }

      [HttpGet("/cities")]
        public ActionResult Cities()
        {
            return View("Cities", City.GetAll());
        }

        [HttpPost("/cities")]
        public ActionResult SortCities()
        {
            City.SetSortCondition(Request.Form["button"]);
            return View("Cities", City.Sort());
        }

        [HttpGet("/countries")]
        public ActionResult Countries()
        {
            return View("Countries", Country.GetAll());
        }

        [HttpPost("/countries")]
        public ActionResult SortCountries()
        {
            Country.SetSortCondition(Request.Form["button"]);
            return View("Countries", Country.Sort());
        }

        [HttpGet("/countries/{id}")]
        public ActionResult Detail(string id)
        {
            return View("Detail", City.Find(id));
        }
    }
}
