using Microsoft.AspNetCore.Mvc;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon
{
  public class Stylist
  {
    private int _stylistId;
    private string _stylistFirstName;
    private string _stylistLastName;
    private static string _sortCondition;

    public Stylist (string firstName, string lastName, int Id = 0)
    {
      _stylistId = Id;
      _stylistFirstName = firstName;
      _stylistLastName = lastName;
    }

    public int GetStylistId(){return _stylistId;}
    public string GetStylistFirstName(){return _stylistFirstName;}
    public string GetStylistLastName(){return _stylistLastName;}

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = (this.GetStylistId() == newStylist.GetStylistId());
        bool firstNameEquality = (this.GetStylistFirstName() == newStylist.GetStylistFirstName());
        bool lastNameEquality = (this.GetStylistLastName() == newStylist.GetStylistLastName());
        return (idEquality && firstNameEquality && lastNameEquality);
      }
    }

    public override int GetHashCode()
    {
      return this.GetStylistFirstName().GetHashCode();
    }

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
          int stylistId = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);

          Stylist newStylist = new Stylist(firstName, lastName, stylistId);
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allStylists;
      }


    // public static List<Stylist> Find(int id)
    // {
    //   List<Stylist> findStylists = new List<Stylist> {};
    //     MySqlConnection conn = DB.Connection();
    //     conn.Open();
    //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //     cmd.CommandText = @"SELECT * FROM stylists WHERE StylistID = (@searchID);";
    //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //
    //     MySqlParameter searchID = new MySqlParameter();
    //     searchID.ParameterName = "searchID";
    //     searchID.Value = id;
    //     cmd.Parameters.Add(searchID);
    //
    //
    //     while(rdr.Read())
    //     {
    //       int stylistID = rdr.GetInt32(0);
    //       string firstName = rdr.GetString(1);
    //       string lastName = rdr.GetString(2);
    //       int clientID = rdr.GetInt32(3);
    //
    //       Stylist newStylist = new Stylist(firstName, lastName, stylistID);
    //       findStylists.Add(newStylist);
    //     }
    //     conn.Close();
    //     if (conn != null)
    //     {
    //         conn.Dispose();
    //     }
    //     return findStylists;
    // }

    public static Stylist Find(int id)
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
      int stylistId = 0;
      string firstName = "";
      string lastName = "";

      while(rdr.Read())
      {
        stylistId = rdr.GetInt32(0);
        firstName = rdr.GetString(1);
        lastName = rdr.GetString(2);
      }
      Stylist newStylist = new Stylist(firstName, lastName, stylistId);
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return newStylist;
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
          int stylistId = rdr.GetInt32(0);
          string firstName = rdr.GetString(1);
          string lastName = rdr.GetString(2);

          Stylist newStylist = new Stylist(firstName, lastName, stylistId);
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
      if (condition == "1"){_sortCondition = "firstName ASC";}
      else if (condition == "2"){_sortCondition = "firstName DESC";}
      else if (condition == "3"){_sortCondition = "lastName ASC";}
      else if (condition == "4"){_sortCondition = "lastName DESC";}
    }

    public static void Clear()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists; ALTER TABLE stylists AUTO_INCREMENT = 1;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`firstName`, `lastName`) VALUES (@FirstName, @LastName);";

      MySqlParameter stylistFirst = new MySqlParameter();
      stylistFirst.ParameterName = "@FirstName";
      stylistFirst.Value = this._stylistFirstName;
      cmd.Parameters.Add(stylistFirst);

      MySqlParameter stylistLast = new MySqlParameter();
      stylistLast.ParameterName = "@LastName";
      stylistLast.Value = this._stylistLastName;
      cmd.Parameters.Add(stylistLast);

      cmd.ExecuteNonQuery();
      _stylistId = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null){conn.Dispose();}
    }

  }
}
