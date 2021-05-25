using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technician_Ticket
{
    public class BillableTicket : Ticket
    {
        private double hourlyRate;
        public BillableTicket(string description, string department, double rate) : base(description, department)
        {
            this.hourlyRate = rate;
        }
        public double GetTotalAmount()
        {
            return (this.Minutes / 60.0) * this.hourlyRate;
        }
    }
}
