using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technician_Ticket
{
    /// <summary>
    /// A Technician represents a technical employee who can be assigned to work on 
    /// tasks (recorded as tickets). Technicians can be working on multiple 
    /// tickets at the same time. The Technician class also enables calculating simple 
    /// statistics about the technicians performance (number of tickets, amount of
    /// time spent on tickets etc).
    /// </summary>
    public class Technician
    {
        private List<Ticket> tickets;
        public string Name { get; set; }

        /// <summary>
        /// Create a new Technicial object.
        /// </summary>
        /// <param name="name">First and last name of the technician.</param>
        public Technician(string name)
        {
            this.Name = name;
            this.tickets = new List<Ticket>();
        }

        /// <summary>
        /// Assigns the ticket to the technician
        /// </summary>
        /// <param name="ticket">A Ticket object</param>
        public void AddTicket(Ticket ticket)
        {
            this.tickets.Add(ticket);
        }

        /// <summary>
        /// Returns the total duration of all the tickets the technician has been assigned
        /// </summary>
        /// <returns>Total duration of all tickets</returns>
        public int TotalDuration()
        {
            int duration = 0;
            foreach (Ticket t in this.tickets)
            {
                duration += t.Minutes;
            }
            return duration;
        }

        /// <summary>
        /// Returns the duration of either open or closed tickets assigned to the technician    
        /// </summary>
        /// <param name="open">True: return duration of open tickets. False: return duration of closed tickets</param>
        /// <returns></returns>
        public int TotalDuration(bool open)
        {
            int duration = 0;
            foreach (Ticket t in this.tickets)
            {
                if (!t.IsClosed == open)
                {
                    duration += t.Minutes;
                }
            }
            return duration;
        }

        /// <summary>
        /// Return the total number of tickets assigned to this technician
        /// </summary>
        /// <returns>total number of tickets assigned to this technician</returns>
        public int NumberTickets()
        {
            return this.tickets.Count;
        }




        /// <summary>
        ///  Return how many tickets this technician has for a given department
        /// </summary>
        /// <param name="department">Name of department</param>
        /// <returns>Number of tickets this technician has been assigned for the given department</returns>
        public int NumberTickets(String department)
        {
            int numTickets = 0;
            foreach (Ticket t in this.tickets)
            {
                if (t.Department == department)
                {
                    numTickets++;
                }
            }
            return numTickets;
        }


        /// <summary>
        ///  Sort the tickets according to their natural sort order.
        /// Tickets are sorted by department.        
        /// </summary>
        public void SortTickets()
        {
            this.tickets.Sort();
        }

        /// <summary>
        ///  Simple method to print all the tickets
        /// </summary>
        public void PrintTicket()
        {
            foreach (Ticket t in tickets)
            {
                Console.WriteLine(t);
            }
        }

        /// <summary>
        /// Sort the tickets and print them
        /// </summary>
        public void PrintTicketSorted()
        {
            SortTickets();
            PrintTicket();
        }

        /// <summary>
        ///  Return the sort order of the tickets. This has no practical purpose and
        /// is just for testing. You don;t need to understand how this method works to
        /// complete the rest of the program.         
        /// </summary>
        /// <returns>an array of int holding the ids in the order they are sorted into</returns>
        public int[] SortOrder()
        {
            int[] result = new int[tickets.Count];
            int j = 0;
            foreach (Ticket t in tickets)
            {
                result[j] = t.ID;
                j++;
            }
            return result;
        }

    }

}
