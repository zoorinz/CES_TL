using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace RoutePlanningCES.Tests.DAL
{
    [TestClass]
    public class TLContextTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            TLInitializer initializer = new TLInitializer();
            initializer.PopulateDatabase();
        }
    }
}
