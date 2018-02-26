using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mike_albers_test;";
    }

    public void Dispose()
    {
      Stylist.Clear();
    }

    [TestMethod]
    public void GetAll_StylistsEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Stylist oneStylist = new Stylist("Jimmy", "John");
      Stylist twoStylist = new Stylist("Jimmy", "John");

      //Assert
      Assert.AreEqual(oneStylist, twoStylist);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToStylist_Id()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jimmy", "John");
      newStylist.Save();

      //Act
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetStylistID();
      int testID = newStylist.GetStylistID();

      //Assert
      Assert.AreEqual(result, testID);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jimmy", "John");
      newStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetStylistID());

      //Assert
      Assert.AreEqual(newStylist, foundStylist);
    }
  }
}
