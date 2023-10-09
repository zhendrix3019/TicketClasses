class Program
{
    static void Main(string[] args)
    {
        string csvFilePath = "Tickets.csv";
        TicketManager ticketManager = new TicketManager(csvFilePath);

        while (true)
        {
            Console.WriteLine("Enter Ticket ID:");
            int ticketId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Summary:");
            string summary = Console.ReadLine();

            Console.WriteLine("Enter Status:");
            string status = Console.ReadLine();

            Console.WriteLine("Enter Priority:");
            string priority = Console.ReadLine();

            Console.WriteLine("Enter Submitter:");
            string submitter = Console.ReadLine();

            Console.WriteLine("Enter Assigned:");
            string assigned = Console.ReadLine();

            Console.WriteLine("Enter Watching (separated by '|'):");
            string watchingInput = Console.ReadLine();
            List<string> watching = new List<string>(watchingInput.Split('|'));

            Ticket newTicket = new Ticket
            {
                TicketID = ticketId,
                Summary = summary,
                Status = status,
                Priority = priority,
                Submitter = submitter,
                Assigned = assigned,
                Watching = watching
            };

            ticketManager.AddTicket(newTicket);
            Console.WriteLine("Record added successfully!");

            Console.WriteLine("Do you want to add another record? (yes/no)");
            string anotherRecord = Console.ReadLine().ToLower();
            if (anotherRecord != "yes")
                break;
        }
    }
}