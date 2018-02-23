using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using System;
using HairSalon.Models;

namespace HairSalon
{
  public class Client
  {
    private int _clientID;
    private string _clientFirstName;
    private string _clientLastName;
    private int _stylistID;
    private static string _sortCondition;

    public Client (int ID, string firstName, string lastName, int stylistID)
    {
      _clientID = ID;
      _clientFirstName = firstName;
      _clientLastName = lastName;
      _stylistID = stylistID;
    }

    public string GetClientFirstName(){return _clientFirstName;}
    public string GetClientLastName(){return _clientLastName;}
    public int GetStylistID(){return _stylistID;}

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool firstNameEquality = (this.GetClientFirstName() == newClient.GetClientFirstName());
        return (firstNameEquality);
      }
    }

    public static List<Client> GetAll()
      {
        List<Client> allClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int stylistID = rdr.GetInt32(3);
          Client newClient = new Client(clientID, firstName, lastName, stylistID);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
      }


    public static List<Client> Find(string input)
    {
      List<Client> findClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients WHERE StylistID = '" + input + "';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int stylistID = rdr.GetInt32(3);

          Client newClient = new Client(clientID, firstName, lastName, stylistID);
          findClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return findClients;
    }

    public static List<Client> Sort()
    {
      List<Client> sortClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients ORDER BY " + _sortCondition + ";";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientID = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);
          int stylistID = rdr.GetInt32(3);

          Client newClient = new Client(clientID, firstName, lastName, stylistID);
          sortClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return sortClients;
    }
    public static void SetSortCondition(string condition)
    {
      if (condition == "1"){_sortCondition = "FirstName ASC";}
      else if (condition == "2"){_sortCondition = "FirstName DESC";}
      else if (condition == "3"){_sortCondition = "LastName ASC";}
      else if (condition == "4"){_sortCondition = "LastName DESC";}
      else if (condition == "5"){_sortCondition = "StylistID ASC";}
      else if (condition == "6"){_sortCondition = "stylistID DESC";}
    }

    public static void Clear()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients; ALTER TABLE clients AUTO_INCREMENT = 1;";
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
      INSERT INTO `clients` (`firstName`) VALUES (@FirstName);
      INSERT INTO `clients` (`lastName`) VALUES (@LastName);
      INSERT INTO `clients` (`clientID`) VALUES (@Client);";

      MySqlParameter clientFirst = new MySqlParameter();
      clientFirst.ParameterName = "@FirstName";
      clientFirst.Value = this._clientFirstName;
      cmd.Parameters.Add(clientFirst);

      MySqlParameter clientLast = new MySqlParameter();
      clientLast.ParameterName = "@LastName";
      clientLast.Value = this._clientLastName;
      cmd.Parameters.Add(clientLast);

      MySqlParameter clientStylist = new MySqlParameter();
      clientStylist.ParameterName = "@Client";
      clientStylist.Value = this._stylistID;
      cmd.Parameters.Add(clientStylist);

      cmd.ExecuteNonQuery();
      _clientID = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null){conn.Dispose();}
    }

  }
}
