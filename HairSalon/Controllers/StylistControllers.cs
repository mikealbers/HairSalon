using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
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
