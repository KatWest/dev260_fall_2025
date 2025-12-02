
namespace AdventurerGuild
{
    public class MonsterSystem
    {
        private Dictionary<string, Monster> monsterDict;
        private int operationCount;

        public MonsterSystem()
        {
            operationCount = 0;
            monsterDict = new Dictionary<string, Monster>();

            Console.WriteLine("Monster System Initialized!");
            Console.WriteLine("Ready for operation.\n");
        } 

        public List<Monster> GetMonsters()
        {
            return monsterDict.Values.ToList();
        }
        public Monster? GetMonster(string name)
        {
            Monster mon;
            return monsterDict.TryGetValue(name.ToLowerInvariant(), out mon) ? mon : null;
        }
        public bool AddMonster(string name, string? discription, Difficulty difficulty)
        {
            var newMonster = new Monster(name, discription, difficulty);
            return monsterDict.TryAdd(name.ToLowerInvariant(), newMonster);            
        }
        public bool EditMonster(string name, string? discription, Difficulty? difficulty)
        {
            Monster mon;
            if (monsterDict.TryGetValue(name.ToLowerInvariant(), out mon))
            {
                if (!string.IsNullOrEmpty(discription) && mon.Discription != discription)
                    mon.Discription = discription;
                if (difficulty != null && mon.Difficulty != difficulty)
                    mon.Difficulty = (Difficulty)difficulty;
                return true;
            }
            return false;
        }
        public bool RemoveMonster(string name)
        {
            Monster mon;
            if (monsterDict.TryGetValue(name.ToLowerInvariant(), out mon))
            {
                monsterDict.Remove(name.ToLowerInvariant());
                return true;
            }
            return false;
        }

    }
}