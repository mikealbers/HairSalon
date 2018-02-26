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
    private int _stylistID = 0;
    private static string _sortCondition;

    public Client (string firstName, string lastName, int ID = 0)
    {
      _clientID = ID;
      _clientFirstName = firstName;
      _clientLastName = lastName;
    }

    public string GetClientFirstName(){return _clientFirstName;}
    public string GetClientLastName(){return _clientLastName;}
    public int GetClientID(){return _clientID;}

    public override bool Equals(System.Object otherClient)
    {
      if(!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetClientID() == newClient.GetClientID());
        bool firstNameEquality = (this.GetClientFirstName() == newClient.GetClientFirstName());
        bool lastNameEquality = (this.GetClientLastName() == newClient.GetClientLastName());
        return (idEquality && firstNameEquality && lastNameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetClientFirstName().GetHashCode();
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
          Client newClient = new Client(firstName, lastName, clientID);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
      }


      public static Client Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int clientId = 0;
        string firstName = "";
        string lastName = "";

        while(rdr.Read())
        {
          clientId = rdr.GetInt32(0);
          firstName = rdr.GetString(1);
          lastName = rdr.GetString(2);
        }
        Client newClient = new Client(firstName, lastName, clientId);
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return newClient;
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

          Client newClient = new Client(firstName, lastName, clientID);
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
      INSERT INTO `clients` (`firstName`, `lastName`, `stylistID`) VALUES (@FirstName, @LastName, @Stylist);";

      MySqlParameter clientFirst = new MySqlParameter();
      clientFirst.ParameterName = "@FirstName";
      clientFirst.Value = this._clientFirstName;
      cmd.Parameters.Add(clientFirst);

      MySqlParameter clientLast = new MySqlParameter();
      clientLast.ParameterName = "@LastName";
      clientLast.Value = this._clientLastName;
      cmd.Parameters.Add(clientLast);

      MySqlParameter clientStylist = new MySqlParameter();
      clientStylist.ParameterName = "@Stylist";
      clientStylist.Value = this._stylistID;
      cmd.Parameters.Add(clientStylist);

      cmd.ExecuteNonQuery();
      _clientID = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null){conn.Dispose();}
    }

  }
}
