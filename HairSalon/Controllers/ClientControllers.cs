using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
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
      return View("ClientsCleared", Client.GetAll());
    }
  }
}
