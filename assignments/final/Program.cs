using System;

namespace AdventurerGuild
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adventurer's Guild System - Final Assignment");
            Console.WriteLine("=============================================");
            
            try
            {
                var guildSystem = new GuildSystem();
                var navigator = new GuildSystemNavigator(guildSystem);

                navigator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Fatal Application Error: {ex.Message}");
                Console.WriteLine("\n🔧 Debug Information:");
                Console.WriteLine($"   Error Type: {ex.GetType().Name}");
                Console.WriteLine($"   Stack Trace: {ex.StackTrace}");
                
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();                
            }
            
        }
    }
}