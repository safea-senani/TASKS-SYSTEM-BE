using System;

namespace ticketingSystem_1.Controllers
{
    public class Ticket : ticket
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Project { get; set; }
        public int Assignee { get; set; }
        public int Status { get; set; }
        public int Priorty { get; set; }
    }
}