namespace TicketApp.Models
{
    class EnhancementTicket : BaseTicket
    {
        public string Software { get; set; }
        public string Cost { get; set; }
        public string Reason { get; set; }
        public string Estimate { get; set; }

        public string ToCsvString()
        {
            string watching = string.Join("|", Watching);
            return $"{TicketID},{Summary},{Status},{Priority},{Submitter},{Assigned},{watching},{Software},{Cost},{Reason},{Estimate}";
        }
    }
}