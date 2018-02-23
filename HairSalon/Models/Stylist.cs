using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon
{
  public class Stylist
  {
    private int _stylistID;
    private string _stylistFirstName;
    private string _stylistLastName;
    private int _clientID;
    private static string _sortCondition;

    public Stylist (int ID, string firstName, string lastName, int clientID)
    {
      _stylistID = ID;
      _stylistFirstName = firstName;
      _stylistLastName = lastName;
      _clientID = clientID;
    }

    public string GetStylistFirstName(){return _stylistFirstName;}
    public string GetStylistLastName(){return _stylistLastName;}
    public int GetStylistID(){return _stylistID;}

    public static List<Stylist> GetAll()
      {
        List<Stylist> allStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylist;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int clientID = rdr.GetInt32(3);

          Stylist newStylist = new Stylist(stylistID, firstName, lastName, clientID);
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allStylists;
      }


    public static List<Stylist> Find(string input)
    {
      List<Stylist> findStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylist WHERE StylistID = '" + input + "';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int clientID = rdr.GetInt32(3);

          Stylist newStylist = new Stylist(stylistID, firstName, lastName, clientID);
          findStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return findStylists;
    }

    public static List<Stylist> Sort()
    {
      List<Stylist> sortStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylist ORDER BY " + _sortCondition + ";";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int clientID = rdr.GetInt32(3);

          Stylist newStylist = new Stylist(stylistID, firstName, lastName, clientID);
          sortStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return sortStylists;
    }
    public static void SetSortCondition(string condition)
    {
      if (condition == "1"){_sortCondition = "FirstName ASC";}
      else if (condition == "2"){_sortCondition = "FirstName DESC";}
      else if (condition == "3"){_sortCondition = "LastName ASC";}
      else if (condition == "4"){_sortCondition = "LastName DESC";}
      else if (condition == "5"){_sortCondition = "ClientID ASC";}
      else if (condition == "6"){_sortCondition = "ClientID DESC";}
    }

  }
}
