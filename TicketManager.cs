class TicketManager
{
    private string csvFilePath;
    private List<Ticket> tickets;

    public TicketManager(string filePath)
    {
        csvFilePath = filePath;
        tickets = LoadTickets();
    }

    public void AddTicket(Ticket ticket)
    {
        tickets.Add(ticket);
        SaveTickets();
    }

    public List<Ticket> GetTickets()
    {
        return tickets;
    }

    private List<Ticket> LoadTickets()
    {
        List<Ticket> loadedTickets = new List<Ticket>();

        if (File.Exists(csvFilePath))
        {
            using (StreamReader sr = File.OpenText(csvFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 7)
                    {
                        Ticket ticket = new Ticket
                        {
                            TicketID = int.Parse(parts[0]),
                            Summary = parts[1],
                            Status = parts[2],
                            Priority = parts[3],
                            Submitter = parts[4],
                            Assigned = parts[5],
                            Watching = new List<string>(parts[6].Split('|'))
                        };
                        loadedTickets.Add(ticket);
                    }
                }
            }
        }

        return loadedTickets;
    }

    private void SaveTickets()
    {
        using (StreamWriter sw = new StreamWriter(csvFilePath))
        {
            foreach (var ticket in tickets)
            {
                sw.WriteLine(ticket.ToCsvString());
            }
        }
    }
}