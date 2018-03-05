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
      int result = savedStylist.GetStylistId();
      int testId = newStylist.GetStylistId();

      //Assert
      Assert.AreEqual(result, testId);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist newStylist = new Stylist("Jimmy", "John");
      newStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(newStylist.GetStylistId());

      //Assert
      Assert.AreEqual(newStylist, foundStylist);
    }

    [TestMethod]
  public void GetClients_RetrievesAllClientsByStylist_ClientList()
  {
    Stylist testStylist = new Stylist("Joan", "Smoath");
    testStylist.Save();

    Client firstClient = new Client("Talon", "Meathawk", testStylist.GetStylistId());
    firstClient.Save();
    Client secondClient = new Client("George", "Mowawn", testStylist.GetStylistId());
    secondClient.Save();


    List<Client> testClientList = new List<Client> {firstClient, secondClient};
    List<Client> resultClientList = testStylist.GetClients();

    CollectionAssert.AreEqual(testClientList, resultClientList);
  }
  }
}
