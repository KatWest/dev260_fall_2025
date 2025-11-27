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
            
        }

        private void DisplayMainMenu()
        {
            
        }
    }
}