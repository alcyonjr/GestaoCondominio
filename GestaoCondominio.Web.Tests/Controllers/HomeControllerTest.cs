using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestaoCondominio.Web.Controllers;

namespace GestaoCondominio.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
