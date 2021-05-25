using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Technician_Ticket;

namespace Technician_Test
{
    [TestClass]
    public class BillableTicketTest
    {
        BillableTicket t;

        [TestInitialize]

        public void Setup()
        {
            double rate = 30.0;
            t = new BillableTicket("New monitor for Joe", "Accounting", rate);
            t.AddTime(90);
        }
        [TestMethod]
        public void TestTotalAmount()
        {
            Assert.AreEqual(45, t.GetTotalAmount());
            t.AddTime(15);
            Assert.AreEqual(52.5, t.GetTotalAmount());
        }
    }
}
