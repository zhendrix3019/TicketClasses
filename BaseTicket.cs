using System.Collections.Generic;

namespace TicketApp.Models
{
    class BaseTicket
    {
        public int TicketID { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Submitter { get; set; }
        public string Assigned { get; set; }
        public List<string> Watching { get; set; }

        public string ToCsvString()
        {
            string watching = string.Join("|", Watching);
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{watching}";
        }
    }
}