using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technician_Ticket
{
    /// <summary>
    /// A ticket represents a request for a technician to work on a specific task.
    /// At the same time it is also used to record how much time is spent on the task
    /// and which department the work is conducted on behalf of. When work is completed
    /// the ticket is marked as closed.
    /// </summary>
    public class Ticket : IComparable<Ticket>
    {
        private int duration; //minutes worked so far on the ticket
        private bool closed; //true if the ticket is closed, false if it's open
        private int id; //unique identifier
        private static int highestID;  //keeps the highest ID issued across all tickets

        /// <summary>
        /// What is the ticket about?
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Department that this ticket is opened for
        /// </summary>
        public string Department { get; set; }


        /// <summary>
        /// Create a new Ticket object.
        /// </summary>
        /// <param name="description">What is the ticket about?</param>
        /// <param name="department">Department that this ticket is opened for</param>
        public Ticket(string description, string department)
        {
            this.Description = description;
            this.Department = department;
            duration = 0;
            highestID++;
            id = highestID;
        }

        /// <summary>
        /// The total number of minutes spent on the ticket
        /// </summary>
        public int Minutes { get { return duration; } }

        public bool IsClosed { get { return closed; } }

        public int ID { get { return id; } }

        /// <summary>
        /// This method moves the ticket to the closed state. If the ticket is already 
        /// closed, this method has no effect.
        /// </summary>
        public void Close()
        {
            this.closed = true;
        }

        /// <summary>
        /// Add time in minutes to the time a technician has worked on the ticket
        /// </summary>
        /// <param name="minutes">Number of minutes to add</param>
        public void AddTime(int minutes)
        {
            this.duration += minutes;
        }

        /// <summary>
        /// Finds the hour portion of the duration of the ticket.
        ///     * If a ticket is less than 60 minutes, return 0,
        ///     * Between 60-119 minutes: return 1
        ///     * Between 120-179 return 2 
        ///     * etc. (there is no limit to number of minutes on a ticket)
        /// </summary>
        /// <returns>The hour part of the duration of a ticket.</returns>
        public int HourPart()
        {
            return this.duration / 60;
        }
        /// <summary>
        /// Finds the minute portion of the ticket when duration is expressed as
        /// hour and minute parts. This is the remainder of the hour part calculation

        ///  Examples:
        ///     * Duration 25 minutes returns 25
        ///     * Duration 85 minutes returns 25
        ///     * Duration 90 minutes returns 30
        /// </summary>
        /// <returns>The minute part of the duration of a ticket.</returns>
        public int MinutePart()
        {
            return this.duration % 60;
        }

        public override string ToString()
        {
            //Accounting: New monitor for Joe - Duration (HH:MM): (0:25) - Status: Open
            return this.Department + ": " + this.Description + " - Duration (HH:MM): (" + HourPart() + ":" + MinutePart() + ") - Status: " + (this.closed ? "Closed" : "Open");
        }


        /////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        /// <summary>
        /// Used for testing purposes. Not relevant to the exam.
        /// </summary>
        public static void ResetID()
        {
            highestID = 0;
        }

        public int CompareTo(Ticket other)
        {
            return this.Department.CompareTo(other.Department);
        }
    }
}


