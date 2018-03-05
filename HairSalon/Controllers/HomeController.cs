using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;
using System.Collections.Generic;

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
      public ActionResult NewClient()
      {
        Client newClient = new Client(Request.Form["firstName"], Request.Form["lastName"], Int32.Parse(Request.Form["stylistId"]));
        newClient.Save();
        return View("Clients", Client.GetAll());
      }

      [HttpGet("/clients/new")]
      public ActionResult ClientsCreateForm()
      {
        return View(Stylist.GetAll());
      }

      [HttpGet("/clients/clear")]
      public ActionResult ClearClients()
      {
        Client.Clear();
        return View("Index", Client.GetAll());
      }

      [HttpGet("/stylists")]
      public ActionResult Stylists()
      {
        return View("Stylists", Stylist.GetAll());
      }

      [HttpGet("/stylists/new")]
      public ActionResult StylistsCreateForm()
      {
        return View("StylistsCreateForm");
      }


      [HttpPost("/stylists")]
      public ActionResult NewStylist()
      {
        Stylist newStylist = new Stylist(Request.Form["firstName"], Request.Form["lastName"]);
        newStylist.Save();
        return View("Stylists", Stylist.GetAll());
      }

      [HttpGet("/stylists/clear")]
      public ActionResult ClearStylists()
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
