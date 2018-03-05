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
      Client oneClient = new Client("Jimmy", "John", 3);
      Client twoClient = new Client("Jimmy", "John", 3);

      //Assert
      Assert.AreEqual(oneClient, twoClient);
    }

    [TestMethod]
    public void Save_DatabaseAssignsIdToClient_Id()
    {
      //Arrange
      Client newClient = new Client("Jimmy", "John", 3);
      newClient.Save();

      //Act
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetClientId();
      int testId = newClient.GetClientId();

      //Assert
      Assert.AreEqual(result, testId);
    }

    [TestMethod]
    public void Find_FindsClientInDatabase_Client()
    {
      //Arrange
      Client newClient = new Client("Jimmy", "John", 3);
      newClient.Save();

      //Act
      Client foundClient = Client.Find(newClient.GetClientId());

      //Assert
      Assert.AreEqual(newClient, foundClient);
    }
  }
}
