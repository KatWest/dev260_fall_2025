using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventurerGuild
{
    public class GuildSystemNavigator
    {
        private readonly GuildSystem guildSystem;
        private bool isRunning;

        public GuildSystemNavigator(GuildSystem guildSystem)
        {
            this.guildSystem = guildSystem ?? throw new ArgumentNullException(nameof(guildSystem));
            this.isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine("Adventurer's Guild System Navigator");
            Console.WriteLine("============================");
            Console.WriteLine();

            while (isRunning)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine()?.ToLower() ?? "";

                Console.WriteLine($"You selected: {choice}");

                try
                {
                    ProcessCommand(choice);
                }
                catch (NotImplementedException ex)
                {
                    Console.WriteLine($"\n❌ Method not implemented yet: {ex.Message}");
                    Console.WriteLine("💡 Implement the TODO method to use this feature.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n❌ Error: {ex.Message}\n");
                }
                
                if (isRunning)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }            
        }

        private void ProcessCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            string command = parts [0].ToLower();
            string[] args = parts.Skip(1).ToArray();

            switch (command)
            {
                case "1":
                case "create":
                    HandleCreateQuestCommand(args);
                    break;
                case "2":
                case "update":
                    HandleUpdateQuestCommand(args);
                    break;
                case "3":
                case "assign":
                    HandleAssignQuestCommand(args);
                    break;
                case "4":
                case "quest":
                case "board":
                    HandleQuestBoardCommand(args);
                    break;
                case "5":
                case "complete":
                    HandleCompleteQuestCommand(args);
                    break;
                case "6":
                case "mob":
                case "monster":
                case "compendium":
                    HandleMonsterCompendiumCommand(args);
                    break;
                case "7":
                case "add":
                case "report":
                    HandleAddMonsterCommand(args);
                    break;
                case "8":
                case "edit":
                    HandleEditMonsterCommand(args);
                    break;
                case "9":
                case "remove":
                    HandleRemoveMonsterCommand(args);
                    break;
                case "q":
                case "10":
                case "quit":
                case "exit":
                    isRunning = false;
                    ShowGoodbye();
                    break;

                default:
                    Console.WriteLine($"❌ Unknown command: '{command}'. Please try again.\n");
                    break;

            }
        }
        private QuestDifficulty ProcessDifficultyCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return QuestDifficulty.Iron;

            string command = parts [0].ToLower();

            switch (command)
            {
                case "1":
                case "wood":
                    return QuestDifficulty.Wood;
                case "2":
                case "copper":
                    return QuestDifficulty.Copper;
                case "3":
                case "iron":
                    return QuestDifficulty.Iron;
                case "4":
                case "bronze":
                    return QuestDifficulty.Bronze;
                case "5":
                case "silver":
                    return QuestDifficulty.Silver;
                case "6":
                case "gold":
                    return QuestDifficulty.Gold;
                case "7":
                case "diamond":
                    return QuestDifficulty.Diamond;                
                default:
                    return QuestDifficulty.Iron;
            }           
        }
        private QuestType ProcessTypeCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return QuestType.Service;

            string command = parts [0].ToLower();

            switch (command)
            {
                case "1":
                case "hunt":
                    return QuestType.Hunt;
                case "2":
                case "gather":
                    return QuestType.Gather;
                case "3":
                case "investigate":
                case "invest":
                case "inv":
                    return QuestType.Investigate;
                case "4":
                case "transport":
                case "trans":
                    return QuestType.Transport;
                case "5":
                case "guard":
                    return QuestType.Guard;
                case "6":
                case "service":
                case "serve":
                    return QuestType.Service;                
                default:
                    return QuestType.Service;
            }          
        }
        private bool ProcessRepeatCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return false;

            string command = parts [0].ToLower();

            switch (command)
            {
                case "y":
                case "yes":
                case "repeat":
                case "repeatable":
                    return true;
                case "n":
                case "no":
                case "dont":
                case "don't":
                    return false;
                default:
                    return false;
            }
        }

        private void DisplayMainMenu()
        {
            // bool isEmpty = guildSystem.IsEmpty();

            Console.WriteLine("┌─ Adventurer's Guild System ──────────────────────────────┐");
            Console.WriteLine("│ 1. Create Quest     │ 2. Update Quest  │ 3. Assign Quest │");
            Console.WriteLine("│ 4. View Quest Board │ 5. Complete Quest│                 │");
            Console.WriteLine("│ 6. View Monster Compendium             │ 7. Add Monster  │");
            Console.WriteLine("│ 8. Edit Monster     │ 9. Remove Monster│                 │");
            Console.WriteLine("│ 10. Quit                                                 │");
            Console.WriteLine("└──────────────────────────────────────────────────────────┘");
        }
        private void ShowGoodbye()
        {
            Console.WriteLine("\n🎓 Thank you for using Guild System Navigator!");            
        }
        private void DisplayDifficultyMenu()
        {
            Console.WriteLine("1. Wood");
            Console.WriteLine("2. Copper");
            Console.WriteLine("3. Iron");
            Console.WriteLine("4. Bronze");
            Console.WriteLine("5. Silver");
            Console.WriteLine("6. Gold");
            Console.WriteLine("7. Diamond");
        }
        private void DisplayTypeMenu()
        {
            Console.WriteLine("1. Hunt");
            Console.WriteLine("2. Gather");
            Console.WriteLine("3. Investigate");
            Console.WriteLine("4. Transport");
            Console.WriteLine("5. Guard");
            Console.WriteLine("6. Service");
        }
        private void HandleCreateQuestCommand(string[] args)
        {
            string questName;
            string questDiscription;
            QuestDifficulty questDifficulty;
            QuestType questType;
            bool repeatable;

            if (args.Length == 0)
            {
                Console.Write("Enter quest name: ");
                questName = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(questName))
                {
                    Console.WriteLine("❌ Invalid quest name provided.");
                    return;                    
                }

                Console.Write("Enter quest discription (optional): ");
                questDiscription = Console.ReadLine()?.Trim() ?? "";

                DisplayDifficultyMenu();
                Console.Write("Enter quest difficulty: ");
                questDifficulty = ProcessDifficultyCommand(Console.ReadLine()?.Trim() ?? "");

                DisplayTypeMenu();
                Console.Write("Enter quest type: ");
                questType = ProcessTypeCommand(Console.ReadLine()?.Trim() ?? "");

                Console.Write("Quest is repeatable? ");
                repeatable = ProcessRepeatCommand(Console.ReadLine()?.Trim() ?? "");

                Console.WriteLine();

                bool success = guildSystem.CreateQuest(questName, questDiscription, questDifficulty, questType, repeatable);

                if (success)
                    Console.WriteLine($"✅ Quest create successfully: {questName}");
                else
                    Console.WriteLine($"❌ Failed to create quest: {questName}");

            }
        }
        private void HandleUpdateQuestCommand(string[] args)
        {
            string questName;
            string questDiscription;
            QuestDifficulty questDifficulty;
            bool repeatable;

            if (args.Length == 0)
            {
                Console.Write("Enter quest name: ");
                questName = Console.ReadLine()?.Trim() ?? "";
                var quest = guildSystem.GetQuest(questName);

                if (string.IsNullOrEmpty(questName) || quest == null)
                {
                    Console.WriteLine("❌ Invalid quest name provided or quest does not exist.");
                    return;
                }

                Console.WriteLine($"Current quest discription: {quest.Discription}");
                Console.Write("Enter updated quest discription (enter to keep): ");
                questDiscription = Console.ReadLine()?.Trim() ?? "";

                DisplayDifficultyMenu();
                Console.WriteLine($"\nCurrent quest difficulty is {quest.Difficulty}");
                Console.Write("Enter updated quest difficulty (enter to keep): ");
                questDifficulty = ProcessDifficultyCommand(Console.ReadLine()?.Trim() ?? "");

                Console.Write($"Quest is currently{(quest.Repeatable ? " " : " not ")}repeatable.\n{(quest.Repeatable ? "Keep quest repeatable? " : "Make quest repeatable? ")}");
                repeatable = ProcessRepeatCommand(Console.ReadLine()?.Trim() ?? "");

                Console.WriteLine();

                bool success = guildSystem.UpdateQuest(questName, questDiscription, questDifficulty, repeatable);

                if (success)
                    Console.WriteLine($"✅ Quest updated successfully: {questName}");
                else
                    Console.WriteLine($"❌ Failed to update quest: {questName}");
            }
        }
        private void HandleAssignQuestCommand(string[] args)
        {
            throw new NotImplementedException();
        }
        private void HandleQuestBoardCommand(string[] args)
        {
            throw new NotImplementedException();
        }
        private void HandleCompleteQuestCommand(string[] args)
        {
            throw new NotImplementedException();
        }
        private void HandleRemoveMonsterCommand(string[] args)
        {
            throw new NotImplementedException();
        }

        private void HandleEditMonsterCommand(string[] args)
        {
            throw new NotImplementedException();
        }

        private void HandleAddMonsterCommand(string[] args)
        {
            throw new NotImplementedException();
        }

        private void HandleMonsterCompendiumCommand(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}