using System;
using System.Collections.Generic;
using TicketApp.Models;

class Program
{
    static void Main(string[] args)
    {
        string BugCsvFilePath = "Tickets.csv";
        string EnhancementsCsvFilePath = "Enhancements.csv";
        string TaskCsvFilePath = "Task.csv";

        TicketManager bugsTicketManager = new TicketManager(BugCsvFilePath);
        TicketManager enhancementsTicketManager = new TicketManager(EnhancementsCsvFilePath);
        TicketManager tasksTicketManager = new TicketManager(TaskCsvFilePath);

        while (true)
        {
            Console.Write("\nSelect Ticket Type\n[1]. Bug/Defect [2]. Enhancement [3]. Task\n\n>>  ");
            int ticketType = int.Parse(Console.ReadLine());

            if (ticketType == 1)
            {
                Console.Write("Enter Ticket ID: ");
                int ticketId = int.Parse(Console.ReadLine());

                Console.Write("Enter Summary: ");
                string summary = Console.ReadLine();

                Console.Write("Enter Status: ");
                string status = Console.ReadLine();

                Console.Write("Enter Priority: ");
                string priority = Console.ReadLine();

                Console.Write("Enter Submitter: ");
                string submitter = Console.ReadLine();

                Console.Write("Enter Assigned: ");
                string assigned = Console.ReadLine();

                Console.Write("Enter Severity: ");
                int severity = int.Parse(Console.ReadLine());

                Console.Write("Enter Watching (separated by '|'): ");
                string watchingInput = Console.ReadLine();
                List<string> watching = new List<string>(watchingInput.Split('|'));

                BugTicket newTicket = new BugTicket
                {
                    TicketID = ticketId,
                    Summary = summary,
                    Status = status,
                    Priority = priority,
                    Submitter = submitter,
                    Assigned = assigned,
                    Watching = watching,
                    Severity = severity
                };

                bugsTicketManager.AddTicket(newTicket);
                Console.Write("\nRecord added successfully!");

            }
            else if (ticketType == 2)
            {

                Console.Write("Enter Ticket ID: ");
                int ticketId = int.Parse(Console.ReadLine());

                Console.Write("Enter Summary: ");
                string summary = Console.ReadLine();

                Console.Write("Enter Status: ");
                string status = Console.ReadLine();

                Console.Write("Enter Priority: ");
                string priority = Console.ReadLine();

                Console.Write("Enter Submitter: ");
                string submitter = Console.ReadLine();

                Console.Write("Enter Assigned: ");
                string assigned = Console.ReadLine();

                Console.Write("Enter Software: ");
                string software = Console.ReadLine();

                Console.Write("Enter Cost: ");
                string cost = Console.ReadLine();

                Console.Write("Enter Reason: ");
                string reason = Console.ReadLine();

                Console.Write("Enter Estimate: ");
                string estimate = Console.ReadLine();

                Console.Write("Enter Watching (separated by '|'): ");
                string watchingInput = Console.ReadLine();
                List<string> watching = new List<string>(watchingInput.Split('|'));

                EnhancementTicket newTicket = new EnhancementTicket
                {
                    TicketID = ticketId,
                    Summary = summary,
                    Status = status,
                    Priority = priority,
                    Submitter = submitter,
                    Assigned = assigned,
                    Watching = watching,
                    Software = software,
                    Cost = cost,
                    Reason = reason,
                    Estimate = estimate,
                };

                enhancementsTicketManager.AddTicket(newTicket);
                Console.Write("\nRecord added successfully!");
            }
            else if (ticketType == 3)
            {
                Console.Write("Enter Ticket ID: ");
                int ticketId = int.Parse(Console.ReadLine());

                Console.Write("Enter Summary: ");
                string summary = Console.ReadLine();

                Console.Write("Enter Status: ");
                string status = Console.ReadLine();

                Console.Write("Enter Priority: ");
                string priority = Console.ReadLine();

                Console.Write("Enter Submitter: ");
                string submitter = Console.ReadLine();

                Console.Write("Enter Assigned: ");
                string assigned = Console.ReadLine();

                Console.Write("Enter ProjectName: ");
                string projectName = Console.ReadLine();

                Console.Write("Enter DueDate: ");
                string dueDate = Console.ReadLine();

                Console.Write("Enter Watching (separated by '|'): ");
                string watchingInput = Console.ReadLine();
                List<string> watching = new List<string>(watchingInput.Split('|'));

                TaskTicket newTicket = new TaskTicket
                {
                    TicketID = ticketId,
                    Summary = summary,
                    Status = status,
                    Priority = priority,
                    Submitter = submitter,
                    Assigned = assigned,
                    Watching = watching,
                    ProjectName = projectName,
                    DueDate = dueDate
                };

                tasksTicketManager.AddTicket(newTicket);
                Console.Write("\nRecord added successfully!");
            }
            else
            {
                Console.Write("\nInvalid Ticket Type -> " + ticketType);
            }

            Console.Write("\nDo you want to add another record? [Y] Yes, [N] No (yes/no): ");

            string anotherRecord = Console.ReadLine().ToLower();
            if (anotherRecord != "yes" && anotherRecord != "y")
            {
                break;
            }
        }
    }
}