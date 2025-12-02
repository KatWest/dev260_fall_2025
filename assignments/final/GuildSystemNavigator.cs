using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventurerGuild
{
    public class GuildSystemNavigator
    {
        private readonly GuildSystem guildSystem;
        private readonly MonsterSystem monsterSystem;
        private bool isRunning;

        public GuildSystemNavigator(GuildSystem guildSystem, MonsterSystem monsterSystem)
        {
            this.guildSystem = guildSystem ?? throw new ArgumentNullException(nameof(guildSystem));
            this.monsterSystem = monsterSystem ?? throw new ArgumentNullException(nameof(monsterSystem));
            this.isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine("Adventurer's Guild System Navigator");
            Console.WriteLine("============================");
            Console.WriteLine();

            InitQuestPopulate();
            InitMonsterPopulate();

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
        private Difficulty ProcessDifficultyCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return Difficulty.Iron;

            string command = parts [0].ToLower();

            switch (command)
            {
                case "1":
                case "wood":
                    return Difficulty.Wood;
                case "2":
                case "copper":
                    return Difficulty.Copper;
                case "3":
                case "iron":
                    return Difficulty.Iron;
                case "4":
                case "bronze":
                    return Difficulty.Bronze;
                case "5":
                case "silver":
                    return Difficulty.Silver;
                case "6":
                case "gold":
                    return Difficulty.Gold;
                case "7":
                case "diamond":
                    return Difficulty.Diamond;                
                default:
                    return Difficulty.Iron;
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
        private bool ProcessConfirmCommand(string input)
        {
            string[] parts = input.Split (' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return false;

            string command = parts [0].ToLower();

            switch (command)
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
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
            Console.WriteLine();
            Console.WriteLine("Use numbers (1-10) or keywords");
            Console.Write("Enter your choice: ");
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
            Difficulty questDifficulty;
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
            Difficulty questDifficulty;
            bool repeatable;

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
        private void HandleAssignQuestCommand(string[] args)
        {
            string questName;

            Console.Write("Enter quest name: ");
            questName = Console.ReadLine()?.Trim() ?? "";
            var quest = guildSystem.GetQuest(questName);

            if (string.IsNullOrEmpty(questName) || quest == null)
            {
                Console.WriteLine("❌ Invalid quest name provided or quest does not exist.");
                return;
            }

            bool success = guildSystem.AssignQuest(quest);

            if (success)
                Console.WriteLine($"✅ Quest assigned successfully: {questName}");
            else
                Console.WriteLine($"❌ Failed to assign quest: {questName}");
        }
        private void HandleQuestBoardCommand(string[] args)
        {
            Console.WriteLine("┌─ Quest Board ────────────────────────────────────────────┐");
            Console.WriteLine();
            var questList = guildSystem.GetQuests();
            if (questList.Count > 0)
            {
                foreach (Quest quest in questList)
                {
                    Console.WriteLine("┌─ ");
                    Console.WriteLine(quest.ToString());
                    Console.WriteLine("└─ ");                    
                }
            }
            else
                Console.WriteLine("Quest board is empty!");
        }
        private void HandleCompleteQuestCommand(string[] args)
        {
            string questName;

            Console.Write("Enter quest name: ");
            questName = Console.ReadLine()?.Trim() ?? "";
            var quest = guildSystem.GetQuest(questName);

            if (string.IsNullOrEmpty(questName) || quest == null)
            {
                Console.WriteLine("❌ Invalid quest name provided or quest does not exist.");
                return;
            }
            bool success = guildSystem.CompleteQuest(quest);

            if (success)
                Console.WriteLine($"✅ Quest completed successfully: {questName}");
            else
                Console.WriteLine($"❌ Failed to complete quest: {questName}");            
        }

        private void HandleMonsterCompendiumCommand(string[] args)
        {
            Console.WriteLine("┌─ Monster Compendium──────────────────────────────────────┐");
            Console.WriteLine();
            var monsterList = monsterSystem.GetMonsters();
            if (monsterList.Count > 0)
            {
                foreach (Monster monster in monsterList)
                {
                    Console.WriteLine("┌─ ");
                    Console.WriteLine(monster.ToString());
                    Console.WriteLine("└─ ");                    
                }
            }
            else
                Console.WriteLine("Monster Compendium is empty!");
        }
        private void HandleAddMonsterCommand(string[] args)
        {
            string monsterName;
            string monsterDiscription;
            Difficulty monsterDifficulty;

            if (args.Length == 0)
            {
                Console.Write("Enter monster name: ");
                monsterName = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrEmpty(monsterName))
                {
                    Console.WriteLine("❌ Invalid monster name provided or monster does not exist.");
                    return;                    
                }

                Console.Write("Enter monster discription (optional): ");
                monsterDiscription = Console.ReadLine()?.Trim() ?? "";

                DisplayDifficultyMenu();
                Console.Write("Enter monster difficulty: ");
                monsterDifficulty = ProcessDifficultyCommand(Console.ReadLine()?.Trim() ?? "");

                Console.WriteLine();

                bool success = monsterSystem.AddMonster(monsterName, monsterDiscription, monsterDifficulty);

                if (success)
                    Console.WriteLine($"✅ Monster added successfully: {monsterName}");
                else
                    Console.WriteLine($"❌ Failed to add monster: {monsterName}");
            }
        }
        private void HandleEditMonsterCommand(string[] args)
        {
            string monsterName;
            string monsterDiscription;
            Difficulty monsterDifficulty;

            if (args.Length == 0)
            {
                Console.Write("Enter monster name: ");
                monsterName = Console.ReadLine()?.Trim() ?? "";
                var monster = monsterSystem.GetMonster(monsterName);

                if (string.IsNullOrEmpty(monsterName) || monster == null)
                {
                    Console.WriteLine("❌ Invalid monster name provided or monster is not recorded in the Monster Compendium.");
                    return;                    
                }

                Console.WriteLine($"Current monster discription: {monster.Discription}");
                Console.Write("Enter updated monster discription (enter to keep): ");
                monsterDiscription = Console.ReadLine()?.Trim() ?? "";

                DisplayDifficultyMenu();
                Console.WriteLine($"\nCurrent monster difficulty is {monster.Difficulty}");
                Console.Write("Enter monster difficulty (enter to keep): ");
                monsterDifficulty = ProcessDifficultyCommand(Console.ReadLine()?.Trim() ?? "");

                Console.WriteLine();

                bool success = monsterSystem.EditMonster(monsterName, monsterDiscription, monsterDifficulty);

                if (success)
                    Console.WriteLine($"✅ Monster updated successfully: {monsterName}");
                else
                    Console.WriteLine($"❌ Failed to update monster: {monsterName}");
            }
        }
        private void HandleRemoveMonsterCommand(string[] args)
        {
            string monsterName;

            if (args.Length == 0)
            {
                Console.Write("Enter monster name: ");
                monsterName = Console.ReadLine()?.Trim() ?? "";
                var monster = monsterSystem.GetMonster(monsterName);

                if (string.IsNullOrEmpty(monsterName) || monster == null)
                {
                    Console.WriteLine("❌ Invalid monster name provided or monster is not recorded in the Monster Compendium.");
                    return;                    
                }
                Console.WriteLine($"Selected monster:\n{monster}");
                Console.Write("\nRemove this monster from the compendium? ");

                // var confirm = ProcessConfirmCommand(Console.ReadLine()?.Trim() ?? "");
                if (ProcessConfirmCommand(Console.ReadLine()?.Trim() ?? ""))
                {
                    // var success = monsterSystem.RemoveMonster(monsterName);
                    if (monsterSystem.RemoveMonster(monsterName))
                        Console.WriteLine($"✅ Monster removed successfully: {monsterName}");
                    else
                        Console.WriteLine($"❌ Failed to remove monster: {monsterName}");       
                }
            }
        }

        private void InitQuestPopulate()
        {
            guildSystem.CreateQuest(
                "Hunt Horned Rabbit",
                "",
                Difficulty.Copper,
                QuestType.Hunt,
                true
            );
            guildSystem.CreateQuest(
                "Collect Herbs",
                "",
                Difficulty.Wood,
                QuestType.Gather,
                true
            );
            guildSystem.CreateQuest(
                "Find location of \"Red Wolf\" Bandit hideout",
                "",
                Difficulty.Silver,
                QuestType.Investigate,
                false
            );
            guildSystem.CreateQuest(
                "Guard Merchant",
                "",
                Difficulty.Bronze,
                QuestType.Guard,
                false
            );
        }
        private void InitMonsterPopulate()
        {
            monsterSystem.AddMonster(
                "Horned Rabbit",
                "A large rabbit with a horn on it's forhead",
                Difficulty.Copper
            );
            monsterSystem.AddMonster(
                "Goblin",
                "A short green creature",
                Difficulty.Iron
            );
            monsterSystem.AddMonster(
                "Storm Hawk",
                "A large bird of prey that can use wind magic",
                Difficulty.Silver
            );
        }
    }
}