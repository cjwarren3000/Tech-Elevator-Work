using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Capstone.Tests
{
    [TestClass]
    public class AddReservationTest : ParentTest
    {
        [TestMethod]
        public void MakeSureReservationIsInTheDatabase()
        {

            VenueAccess va = new VenueAccess(connectionString);

            bool result = va.AddReservation(1, 1, "2020-06-28", "2020-07-04", "Matt Eland");

            Assert.IsTrue(result);

            
        }
    }
}

