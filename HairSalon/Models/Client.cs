using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldData.Models;

namespace HairSalon
{
  public class Client
  {
    private int _clientID;
    private string _clientFirstName;
    private string _clientLastName;
    private int _stylistID;
    private static string _sortCondition;

    public Client (int id, string firstName, string lastName, int stylistID)
    {
      _clientID = id;
      _clientFirstName = firstName;
      _clientLastName = lastName;
      _stylistID = stylistID;
    }
  }
}
