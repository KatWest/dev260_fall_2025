using System;
using System.Collections.Generic;

/*
=== QUICK REFERENCE GUIDE ===

Stack<T> Essential Operations:
- new Stack<string>()           // Create empty stack
- stack.Push(item)              // Add item to top (LIFO)
- stack.Pop()                   // Remove and return top item
- stack.Peek()                  // Look at top item (don't remove)
- stack.Clear()                 // Remove all items
- stack.Count                   // Get number of items

Safety Rules:
- ALWAYS check stack.Count > 0 before Pop() or Peek()
- Empty stack Pop() throws InvalidOperationException
- Empty stack Peek() throws InvalidOperationException

Common Patterns:
- Guard clause: if (stack.Count > 0) { ... }
- LIFO order: Last item pushed is first item popped
- Enumeration: foreach gives top-to-bottom order

Helpful icons!:
- ✅ Success
- ❌ Error
- 👀 Look
- 📋 Display out
- ℹ️ Information
- 📊 Stats
- 📝 Write
*/

namespace StackLab
{
    /// <summary>
    /// Student skeleton version - follow along with instructor to build this out!
    /// Uncomment the class name and Main method when ready to use this version.
    /// </summary>
    // class Program  // Uncomment this line when ready to use
    class StudentSkeleton
    {

        // TODO: Step 1 - Declare two stacks for action history and undo functionality

        private static Stack<string> actionHistory = new Stack<string>();
        private static Stack<string> undoHistory = new Stack<string>();
        private static int totalOperations = 0;

        // TODO: Step 2 - Add a counter for total operations

        static void Main(string[] args)
        {
            Console.WriteLine("=== Interactive Stack Demo ===");
            Console.WriteLine("Building an action history system with undo/redo\n");

            bool running = true;
            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine()?.ToLower() ?? "";

                switch (choice)
                {
                    case "1":
                    case "push":
                        HandlePush();
                        break;
                    case "2":
                    case "pop":
                        HandlePop();
                        break;
                    case "3":
                    case "peek":
                    case "top":
                        HandlePeek();
                        break;
                    case "4":
                    case "display":
                        HandleDisplay();
                        break;
                    case "5":
                    case "clear":
                        HandleClear();
                        break;
                    case "6":
                    case "undo":
                        HandleUndo();
                        break;
                    case "7":
                    case "redo":
                        HandleRedo();
                        break;
                    case "8":
                    case "stats":
                        ShowStatistics();
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
            Console.WriteLine("┌─ Stack Operations Menu ─────────────────────────┐");
            Console.WriteLine("│ 1. Push      │ 2. Pop       │ 3. Peek/Top    │");
            Console.WriteLine("│ 4. Display   │ 5. Clear     │ 6. Undo        │");
            Console.WriteLine("│ 7. Redo      │ 8. Stats     │ 9. Exit        │");
            Console.WriteLine("└─────────────────────────────────────────────────┘");
            // TODO: Step 3 - add stack size and total operations to our display
            Console.WriteLine($"Current stack size: {actionHistory.Count} | Total operations: {totalOperations}");
            Console.Write("\nChoose operation (number or name): ");
        }

        // TODO: Step 4 - Implement HandlePush method
        static void HandlePush()
        {
            // TODO: 
            Console.Write("Enter action to add to history: ");
            string? action = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(action))
            {
                actionHistory.Push(action.Trim());
                undoHistory.Clear();
                totalOperations++;
                Console.WriteLine($"✅ Pushed '{action}'");
            }
            else
                Console.WriteLine("❌ Action cannot be empty.");
            
        }

        // TODO: Step 5 - Implement HandlePop method
        static void HandlePop()
        {
            if (actionHistory.Count > 0)
            {
                string poppedAction = actionHistory.Pop();
                undoHistory.Push(poppedAction);
                totalOperations++;
                Console.WriteLine($"✅ Popped '{poppedAction}'");
                if (actionHistory.Count > 0)
                    Console.WriteLine($"👀 New top action: {actionHistory.Peek()}");
                else
                    Console.WriteLine("ℹ️ History is now empty");
            }
        }

        // TODO: Step 6 - Implement HandlePeek method
        static void HandlePeek()
        {
            if (actionHistory.Count > 0)
            {
                string topAction = actionHistory.Peek();
                Console.WriteLine($"👀 Top action: '{topAction}'\n");
            }
            else
                Console.WriteLine("❌ History is empty. Nothing to peek");
        }

        // TODO: Step 7 - Implement HandleDisplay method
        static void HandleDisplay()
        {
            Console.WriteLine(" Current History Stack (TTB - Toop to Bottom)");

            if (actionHistory.Count == 0)
                Console.WriteLine("\n History is empty.\n");
            else
            {
                int position = actionHistory.Count;
                foreach (string action in actionHistory)
                {
                    string marker = position == 1 ? " Top" : "   ";
                    Console.WriteLine($" {position:D2}. {action} {marker}");
                    position--;
                }
            }
            Console.WriteLine();
        }

        // TODO: Step 8 - Implement HandleClear method
        static void HandleClear()
        {
            if (actionHistory.Count > 0)
            {
                int clearedCount = actionHistory.Count;
                actionHistory.Clear();
                undoHistory.Clear();
                totalOperations++;
                Console.WriteLine($"✅ Cleared {clearedCount} actions from history.");
            }
            else
                Console.WriteLine(" History is already empty.");
        }

        // TODO: Step 9 - Implement HandleUndo method (Advanced)
        static void HandleUndo()
        {
            if (undoHistory.Count > 0)
            {
                string actionToRestore = undoHistory.Pop();
                actionHistory.Push(actionToRestore);
                totalOperations++;
                Console.WriteLine($" Undid action: '{actionToRestore}'");
            }
            else
                Console.WriteLine(" Nothing to undo.\n");
        }

        // TODO: Step 10 - Implement HandleRedo method (Advanced)
        static void HandleRedo()
        {
            if (actionHistory.Count > 0)
            {
                string actionToRemove = actionHistory.Pop();
                undoHistory.Push(actionToRemove);
                totalOperations++;
                Console.WriteLine($" Redid action: '{actionToRemove}'");
            }
            else
                Console.WriteLine(" Nothing to redo.\n");
        }

        // TODO: Step 11 - Implement ShowStatistics method
        static void ShowStatistics()
        {
            Console.WriteLine(" Current Session Statistics");
            Console.WriteLine($"- Current stack size: {actionHistory.Count}");
            Console.WriteLine($"- Current undo history size: {undoHistory.Count}");
            Console.WriteLine($"- Current stack size: {totalOperations}");
            Console.WriteLine($"- Current stack size: {actionHistory.Count}");
            // TODO:
            // Display current session statistics:
            // - Current stack size
            // - Undo stack size
            // - Total operations performed
            // - Whether stack is empty
            // - Current top action (if any)
        }

        // TODO: Step 12 - Implement ShowSessionSummary method
        static void ShowSessionSummary()
        {
            
            // TODO:
            // Show final summary when exiting:
            // - Total operations performed
            // - Final stack size
            // - List remaining actions (if any)
            // - Encouraging message
            // - Wait for keypress before exit
        }
    }
}
