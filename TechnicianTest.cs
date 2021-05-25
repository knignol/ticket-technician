using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Technician_Ticket;

namespace Technician_Test
{
    [TestClass]
    public class TechnicianTest
    {
        Technician tech;
        Ticket t1;
        Ticket t2;
        Ticket t3;
        Ticket t4;

        [TestInitialize]
        public void Setup()
        {
            tech = new Technician("Joe the Tech");
            Ticket.ResetID();
            t1 = new Ticket("Fix Jim's computer", "Accounting");
            t2 = new Ticket("Install Antivirus", "Finance");
            t3 = new Ticket("Replace monitor for Jane", "Accounting");
            t4 = new Ticket("Install MS Office", "Marketing");
            tech.AddTicket(t1);
            tech.AddTicket(t2);
            tech.AddTicket(t3);
            tech.AddTicket(t4);
            t1.AddTime(25);
            t2.AddTime(35);
            t3.AddTime(10);
            t1.Close();

        }
        [TestMethod]
        public void TestAddTicket()
        {
            // Test of adding a ticket to a technician
            Ticket t = new Ticket("Remove virus", "Finance");
            tech.AddTicket(t);
            Assert.AreEqual(5, tech.NumberTickets());
        }

        [TestMethod]
        public void TestTotalDuration()
        {
            // Test of the total duration of all tickets for a tech
            Assert.AreEqual(25 + 35 + 10, tech.TotalDuration());
        }

        [TestMethod]
        public void TestTotalDurationOpen()
        {
            /// Test of the total duration of all open tickets for a tech
            Assert.AreEqual(35 + 10, tech.TotalDuration(true));
        }

        [TestMethod]
        public void TestTotalDurationClosed()
        {
            // Test of the total duration of all closed tickets for a tech
            Assert.AreEqual(25, tech.TotalDuration(false));
        }


        [TestMethod]
        public void testNumberTickets()
        {
            //Test of how many tickets have been assigned to a tech.
            Assert.AreEqual(4, tech.NumberTickets());
        }

        [TestMethod]
        public void testNumTicketsDep()
        {
            // Test of numberTickets by department
            Assert.AreEqual(2, tech.NumberTickets("Accounting"));
        }


        [TestMethod]
        public void testSorting()
        {
            // Test of sorting of tickets.
            // The sortOrder method returns the ids of the tickets in the sorted order.
            tech.SortTickets();
            int[] expResult = { 1, 3, 2, 4 };
            int[] result = tech.SortOrder();
            int i = 0;
            foreach (int j in expResult)
            {
                int res = result[i];
                Assert.AreEqual(j, res);
                i++;
            }
        }

    }
}
