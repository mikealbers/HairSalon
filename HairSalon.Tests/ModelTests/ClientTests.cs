using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=mike_albers_test;";
    }

    public void Dispose()
    {
      Client.Clear();
    }

    [TestMethod]
    public void GetAll_ClientsEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Client.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Client oneClient = new Client("Jimmy", "John");
      Client twoClient = new Client("Jimmy", "John");

      //Assert
      Assert.AreEqual(oneClient, twoClient);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToClient_Id()
    {
      //Arrange
      Client newClient = new Client("Jimmy", "John");
      newClient.Save();

      //Act
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetClientID();
      int testID = newClient.GetClientID();

      //Assert
      Assert.AreEqual(result, testID);
    }

    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      //Arrange
      Client newClient = new Client("Jimmy", "John");
      newClient.Save();

      //Act
      Client foundClient = Client.Find(newClient.GetClientID());

      //Assert
      Assert.AreEqual(newClient, foundClient);
    }
  }
}
