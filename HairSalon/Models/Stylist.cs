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

    public int GetStylistID(){return _stylistID;}
    public string GetStylistFirstName(){return _stylistFirstName;}
    public string GetStylistLastName(){return _stylistLastName;}
    public int GetClientID(){return _clientID;}

    public static List<Stylist> GetAll()
      {
        List<Stylist> allStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
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
        cmd.CommandText = @"SELECT * FROM stylists WHERE StylistID = '" + input + "';";
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
        cmd.CommandText = @"SELECT * FROM stylists ORDER BY " + _sortCondition + ";";
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

    public static void Clear()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists; ALTER TABLE stylists AUTO_INCREMENT = 1;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null){conn.Dispose();}
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"
      INSERT INTO `stylists` (`firstName`) VALUES (@FirstName);
      INSERT INTO `stylists` (`lastName`) VALUES (@LastName);
      INSERT INTO `stylists` (`clientID`) VALUES (@Client);";

      MySqlParameter stylistFirst = new MySqlParameter();
      stylistFirst.ParameterName = "@FirstName";
      stylistFirst.Value = this._stylistFirstName;
      cmd.Parameters.Add(stylistFirst);

      MySqlParameter stylistLast = new MySqlParameter();
      stylistLast.ParameterName = "@LastName";
      stylistLast.Value = this._stylistLastName;
      cmd.Parameters.Add(stylistLast);

      MySqlParameter stylistClient = new MySqlParameter();
      stylistClient.ParameterName = "@Client";
      stylistClient.Value = this._clientID;
      cmd.Parameters.Add(stylistClient);

      cmd.ExecuteNonQuery();
      _stylistID = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null){conn.Dispose();}
    }

  }
}
