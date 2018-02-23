using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
  [TestClass]
  public class HomeControllerTest
  {
     [TestMethod]
     public void Index_ReturnCorrectView_true()
     {
         //Arrange
          HomeController controller = new HomeController();

          //Act
          IActionResult indexView = controller.Index();
          ViewResult result = indexView as ViewResult;

          //Assert
          Assert.IsInstanceOfType(result, typeof(ViewResult));
     }
  }
}
