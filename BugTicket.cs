namespace TicketApp.Models
{
    class BugTicket : BaseTicket
    {
        public int Severity { get; set; }

        public string ToCsvString()
        {
            string watching = string.Join("|", Watching);
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{watching},{Severity}";
        }
    }
}