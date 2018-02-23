using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTest : IDisposable
  {
    public HairSalonTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=salon_test;";
    }

    public void Dispose()
    {
      Client.Clear();
    }

    [TestMethod]
    public void Equals_ReturnsTrueFirstNameSame()
    {
      //Arrange
      //Act
      Client testClient = new Client(1, "Peter", "Bagge", 1);
      Client otherClient = new Client(1, "Peter", "Bagge", 1);

      //Assert
      Assert.AreEqual(testClient, otherClient);
    }
  }
}
