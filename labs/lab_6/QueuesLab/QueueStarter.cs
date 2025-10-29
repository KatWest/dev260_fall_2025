using System;
using System.Collections.Generic;

/*
=== QUICK REFERENCE GUIDE ===

Queue<T> Essential Operations:
- new Queue<SupportTicket>()        // Create empty queue
- queue.Enqueue(item)               // Add item to back (FIFO)
- queue.Dequeue()                   // Remove and return front item
- queue.Peek()                      // Look at front item (don't remove)
- queue.Clear()                     // Remove all items
- queue.Count                       // Get number of items

Safety Rules:
- ALWAYS check queue.Count > 0 before Dequeue() or Peek()
- Empty queue Dequeue() throws InvalidOperationException
- Empty queue Peek() throws InvalidOperationException

Common Patterns:
- Guard clause: if (queue.Count > 0) { ... }
- FIFO order: First item enqueued is first item dequeued
- Enumeration: foreach gives front-to-back order

Helpful Icons:
- ✅ Success
- ❌ Error
- 👀 Look
- 📋 Display
- ℹ️ Information
- 📊 Stats
- 🎫 Ticket
- 🔄 Process
*/

namespace QueuesLab
{
    /// <summary>
    /// Student skeleton version - follow along with instructor to build this out!
    /// Complete the TODO steps to build a complete IT Support Desk Queue system.
    /// </summary>
    class Program
    {
        // TODO Step 1: Set up your data structures and tracking variables
        private static Queue<SupportTicket> ticketQueue = new Queue<SupportTicket>();
        private static int ticketCounter = 1;
        private static int totalOperations = 0;
        private static DateTime sessionStart = DateTime.Now;
        // Pre-defined ticket options for easy selection during demos
        private static readonly string[] CommonIssues = {
            "Login issues - cannot access email",
            "Password reset request",
            "Software installation help",
            "Printer not working",
            "Internet connection problems",
            "Computer running slowly",
            "Email not sending/receiving",
            "VPN connection issues",
            "Application crashes on startup",
            "File recovery assistance",
            "Monitor display problems",
            "Keyboard/mouse not responding",
            "Video conference setup help",
            "File sharing permission issues",
            "Security software alert"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("🎫 IT Support Desk Queue Management");
            Console.WriteLine("===================================");
            Console.WriteLine("Building a ticket queue system with FIFO processing\n");

            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.ToLower() ?? "";

                switch (choice)
                {
                    case "1":
                    case "submit":
                        HandleSubmitTicket();
                        break;
                    case "2":
                    case "process":
                        HandleProcessTicket();
                        break;
                    case "3":
                    case "peek":
                    case "next":
                        HandlePeekNext();
                        break;
                    case "4":
                    case "display":
                    case "queue":
                        HandleDisplayQueue();
                        break;
                    case "5":
                    case "urgent":
                        HandleUrgentTicket();
                        break;
                    case "6":
                    case "search":
                        HandleSearchTicket();
                        break;
                    case "7":
                    case "stats":
                        HandleQueueStatistics();
                        break;
                    case "8":
                    case "clear":
                        HandleClearQueue();
                        break;
                    case "9":
                    case "exit":
                        running = false;
                        ShowSessionSummary();
                        break;
                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.\n");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            string nextTicket = ticketQueue.Count > 0 ? ticketQueue.Peek().TicketId : "None";

            Console.WriteLine("┌─ Support Desk Queue Operations ─────────────────┐");
            Console.WriteLine("│ 1. Submit      │ 2. Process    │ 3. Peek/Next  │");
            Console.WriteLine("│ 4. Display     │ 5. Urgent     │ 6. Search      │");
            Console.WriteLine("│ 7. Stats       │ 8. Clear      │ 9. Exit        │");
            Console.WriteLine("└─────────────────────────────────────────────────┘");
            Console.WriteLine($"Queue: {ticketQueue.Count} tickets | Next: {nextTicket} | Total ops: {totalOperations}");
            Console.Write("\nChoose operation (number or name): ");
        }

        // TODO Step 2: Handle submitting new tickets (Enqueue)
        static void HandleSubmitTicket()
        {
            Console.WriteLine("\n📝 Submit New Support Ticket");
            Console.WriteLine("Choose from common issues or enter custom:");

            // Math.Min() for safe array access - prevents index out of bounds errors
            // Display quick selection options
            for (int i = 0; i < Math.Min(5, CommonIssues.Length); i++)
            {
                Console.WriteLine($"  {i + 1}. {CommonIssues[i]}");
            }
            Console.WriteLine("  6. Enter custom issue");
            Console.WriteLine("  0. Cancel");
            
            Console.Write("\nSelect option (0-6): ");
            string? choice = Console.ReadLine();
            
            if (choice == "0")
            {
                Console.WriteLine("❌ Ticket submission cancelled.\n");
                return;
            }
            
            string description = "";
            // int.TryParse() for safe number conversion - better than catching exceptions
            if (int.TryParse(choice, out int index) && index >= 1 && index <= 5)
            {
                description = CommonIssues[index - 1];
            }
            else if (choice == "6")
            {
                Console.Write("Enter issue description: ");
                description = Console.ReadLine()?.Trim() ?? "";
            }

            // Input validation with multiple options - professional apps handle user choice
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("❌ Description cannot be empty. Ticket submission cancelled.\n");
                return;
            }

            string ticketId = $"T{ticketCounter:D3}";
            var ticket = new SupportTicket(ticketId, description, "Normal", "User");
            ticketQueue.Enqueue(ticket);
            ticketCounter++;
            totalOperations++;

            Console.WriteLine($" Ticket ID: {ticketId} submitted successfully!");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Postition in queue: {ticketQueue.Count}");
        }

        // TODO Step 3: Handle processing tickets (Dequeue)
        static void HandleProcessTicket()
        {
            Console.WriteLine("\nProcess Next Ticket");
            if (ticketQueue.Count > 0)
            {
                var currTicket = ticketQueue.Dequeue();
                totalOperations++;
                Console.WriteLine($"Processing ticket: {currTicket.ToDetailedString()}");
                if (ticketQueue.Count > 0)
                    Console.WriteLine($"Next ticket: {ticketQueue.Peek().TicketId} - {ticketQueue.Peek().Description}");
                else
                    Console.WriteLine("All tickets have been processed!");
            }
            else
                Console.WriteLine("No tickets in queue to process");
        }

        // TODO Step 4: Handle peeking at next ticket
        static void HandlePeekNext()
        {
            Console.WriteLine("\nView Next Ticket");
            if (ticketQueue.Count > 0)
            {
                var nextTicket = ticketQueue.Peek();
                Console.WriteLine("Next ticket to be processed:");
                Console.WriteLine(nextTicket.ToDetailedString());
                Console.WriteLine($"Position: 1 of {ticketQueue.Count}\n");
            }
            else
                Console.WriteLine("Queue is empty. No tickets to view");
        }

        // TODO Step 5: Handle displaying the full queue
        static void HandleDisplayQueue()
        {
            Console.WriteLine("\nCurrent Support Queue (FIFO Order):");
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine($"Total tickets in queue: {ticketQueue.Count}");
                int p = 1;
                foreach(var ticket in ticketQueue)
                {
                    string nextMarker = p == 1 ? "← Next" : "";
                    Console.WriteLine($"   {p:D2}. {ticket.ToString()}{nextMarker}");
                    p++;
                }
            }
            else
                Console.WriteLine("Queue is empty - no tickets waiting");
        }

        // TODO Step 6: Handle clearing the queue
        static void HandleClearQueue()
        {
            Console.WriteLine("\nClear All Tickets");
            if (ticketQueue.Count > 0)
            {
                var c = ticketQueue.Count;
                Console.Write($"This will remove {c} tickets. Are you sure? (y/N): ");
                string? response = Console.ReadLine()?.ToLower();

                if (response == "y" || response == "yes")
                {
                    ticketQueue.Clear();
                    totalOperations++;
                    Console.WriteLine($"Cleared {c} from the queue.");
                }
                else
                    Console.WriteLine("Clear operation cancelled.");
            }
            else
                Console.WriteLine("Queue is already empty. Nothing to clear");
        }

        // TODO Step 7: Handle urgent ticket submission (Priority)
        static void HandleUrgentTicket()
        {
            Console.WriteLine("\nSubmit Urget Ticket");
            Console.WriteLine("Urgent tickets are processed first! BUT NOT YET");

            Console.Write("Enter urgent issue description: ");
            string? description = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Description cannot be empty");
                return;
            }

            string ticketId = $"U{ticketCounter:D3}";
            var urgentTicket = new SupportTicket(ticketId, description!, "Urgent", "");

            ticketQueue.Enqueue(urgentTicket);
            ticketCounter++;
            totalOperations++;

            Console.WriteLine("Urgent ticket ID: submitted successfully"); ;
            Console.WriteLine("Descriptoin: ");
            Console.WriteLine("position in queue");
            // TODO:
            // 1. Display header "Submit Urgent Ticket"
            // 2. Show explanation: "Urgent tickets are processed first!"
            // 3. Prompt for urgent issue description
            // 4. Validate description is not empty or whitespace
            // 5. If empty, show error and return
            // 6. If valid:
            //    - Create ticket ID using "U" prefix and ticketCounter (format: "U001", "U002", etc.)
            //    - Create new SupportTicket with ID, description, "Urgent" priority, and "User"
            //    - For basic implementation: use regular Enqueue (note: real system would prioritize)
            //    - Increment ticketCounter and totalOperations
            //    - Show success message with ticket ID and description
            //    - Add note explaining that real systems would jump to front of queue
        }

        // TODO Step 8: Handle searching for tickets
        static void HandleSearchTicket()
        {
            Console.WriteLine("Search Support Tickets");

            if (ticketQueue.Count > 0)
            {
                Console.Write("Enter ticket ID or description keyword:");
                string? searchTerm = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    Console.WriteLine("Search term cannot be empty. Search cancelled");
                    return;
                }

                bool found = false;
                int position = 1;
                Console.WriteLine("Search results");
                foreach (var ticket in ticketQueue)
                {
                    if (ticket.TicketId.ToLower().Contains(searchTerm.ToLower()) ||
                        ticket.Description.ToLower().Contains(searchTerm.ToLower()))
                    {
                        Console.WriteLine($"{position:D2} {ticket}");
                        found = true;
                    }
                    position++;
                }

                if (!found)
                    Console.WriteLine("No tickets found matching '{searchTerm}");
                Console.WriteLine();
            }
            else
                Console.WriteLine("Queue is empty. No tickets to search");
        }

        static void HandleQueueStatistics()
        {
            Console.WriteLine("\n📊 Queue Statistics");
            
            TimeSpan sessionDuration = DateTime.Now - sessionStart;
            
            Console.WriteLine($"Current Queue Status:");
            Console.WriteLine($"- Tickets in queue: {ticketQueue.Count}");
            Console.WriteLine($"- Total operations: {totalOperations}");
            Console.WriteLine($"- Session duration: {sessionDuration:hh\\:mm\\:ss}");
            Console.WriteLine($"- Next ticket ID: T{ticketCounter:D3}");
            
            if (ticketQueue.Count > 0)
            {
                var oldestTicket = ticketQueue.Peek();
                Console.WriteLine($"- Longest waiting: {oldestTicket.TicketId} ({oldestTicket.GetFormattedWaitTime()})");
                
                // Count by priority
                int normal = 0, high = 0, urgent = 0;
                foreach (var ticket in ticketQueue)
                {
                    switch (ticket.Priority.ToLower())
                    {
                        case "normal": normal++; break;
                        case "high": high++; break;
                        case "urgent": urgent++; break;
                    }
                }
                Console.WriteLine($"- By priority: 🟢 Normal({normal}) 🟡 High({high}) 🔴 Urgent({urgent})");
            }
            else
            {
                Console.WriteLine("- Queue is empty");
            }
            Console.WriteLine();
        }

        static void ShowSessionSummary()
        {
            Console.WriteLine("\n📋 Final Session Summary");
            Console.WriteLine("========================");
            
            TimeSpan sessionDuration = DateTime.Now - sessionStart;
            
            Console.WriteLine($"Session Statistics:");
            Console.WriteLine($"- Duration: {sessionDuration:hh\\:mm\\:ss}");
            Console.WriteLine($"- Total operations: {totalOperations}");
            Console.WriteLine($"- Tickets remaining: {ticketQueue.Count}");
            
            if (ticketQueue.Count > 0)
            {
                Console.WriteLine($"- Unprocessed tickets:");
                int position = 1;
                foreach (var ticket in ticketQueue)
                {
                    Console.WriteLine($"  {position:D2}. {ticket}");
                    position++;
                }
                Console.WriteLine("\n⚠️ Remember to process remaining tickets!");
            }
            else
            {
                Console.WriteLine("✨ All tickets processed - excellent work!");
            }
            
            Console.WriteLine("\nThank you for using the Support Desk Queue System!");
            Console.WriteLine("You've learned FIFO queue operations and real-world ticket management! 🎫\n");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}