namespace TicketApp.Models
{
    class TaskTicket : BaseTicket
    {
        public string ProjectName { get; set; }
        public string DueDate { get; set; }

        public string ToCsvString()
        {
            string watching = string.Join("|", Watching);
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{watching},{ProjectName},{DueDate}";
        }
    }
}