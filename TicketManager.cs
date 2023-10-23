using System;
using System.Collections.Generic;
using System.IO;
using TicketApp.Models;

class TicketManager
{
    private string csvFilePath;

    private List<BaseTicket> tickets;

    public TicketManager(string filePath)
    {
        csvFilePath = filePath;
        tickets = LoadTickets();
    }

    public void AddTicket(BaseTicket ticket)
    {
        tickets.Add(ticket);
        SaveTickets();
    }

    public List<BaseTicket> GetTickets()
    {
        return tickets;
    }

    private List<BaseTicket> LoadTickets()
    {
        List<BaseTicket> loadedTickets = new List<BaseTicket>();

        if (File.Exists(csvFilePath))
        {
            using (StreamReader sr = File.OpenText(csvFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 8)
                    {
                        BugTicket ticket = new BugTicket
                        {
                            TicketID = int.Parse(parts[0]),
                            Summary = parts[1],
                            Status = parts[2],
                            Priority = parts[3],
                            Submitter = parts[4],
                            Assigned = parts[5],
                            Watching = new List<string>(parts[6].Split('|')),
                            Severity = int.Parse(parts[7])
                        };
                        loadedTickets.Add(ticket);
                    }
                    else if (parts.Length == 9)
                    {
                        TaskTicket ticket = new TaskTicket
                        {
                            TicketID = int.Parse(parts[0]),
                            Summary = parts[1],
                            Status = parts[2],
                            Priority = parts[3],
                            Submitter = parts[4],
                            Assigned = parts[5],
                            Watching = new List<string>(parts[6].Split('|')),
                            ProjectName = parts[7],
                            DueDate = parts[8],
                        };
                        loadedTickets.Add(ticket);
                    }
                    else if (parts.Length == 11)
                    {
                        EnhancementTicket ticket = new EnhancementTicket
                        {
                            TicketID = int.Parse(parts[0]),
                            Summary = parts[1],
                            Status = parts[2],
                            Priority = parts[3],
                            Submitter = parts[4],
                            Assigned = parts[5],
                            Watching = new List<string>(parts[6].Split('|')),
                            Software = parts[7],
                            Cost = parts[8],
                            Reason = parts[9],
                            Estimate = parts[10]
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