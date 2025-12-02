using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventurerGuild
{
    public class GuildSystem
    {
        private List<Quest> questList;
        private List<Quest> assignedQuestList;
        private int operationCount;

        public GuildSystem()
        {
            operationCount = 0;
            questList = new List<Quest>();

            Console.WriteLine("Guild System Navigator Initialized!");
            Console.WriteLine("Ready for operation.\n");
        }

        public List<Quest> GetQuests()
        {
            return questList;
        }
        public Quest GetQuest(string name)
        {
            var quest = questList.FirstOrDefault(q => q.Name == name);
            return quest ?? null;
        }
        public bool CreateQuest(string name, string? discription, Difficulty difficulty, QuestType type, bool? repeatable)
        {
            var newQuest = new Quest(name, discription, difficulty, type, repeatable);
            
            questList.Add(newQuest);

            if (questList.Contains(newQuest))
                return true;
            else return false;
        }
        public bool UpdateQuest(string name, string? discription, Difficulty? difficulty, bool? repeatable)
        {
            var quest = questList.FirstOrDefault(q => q.Name == name);

            if (quest != null)
            {
                if (!string.IsNullOrEmpty(discription) && quest.Discription != discription)
                    quest.Discription = discription;
                if (difficulty != null && quest.Difficulty != difficulty)
                    quest.Difficulty = (Difficulty)difficulty;
                if (repeatable != null && quest.Repeatable != repeatable)
                    quest.Repeatable = (bool)repeatable;
                return true;
            }
            return false;            
        }
        public bool AssignQuest(Quest quest)
        {
            if (quest != null)
            {
                assignedQuestList.Add(quest);
                if (quest.Repeatable == false)
                    questList.Remove(quest);
                return true;
            }
            return false;
        }
        public bool CompleteQuest(Quest quest)
        {
            if (quest != null)
                if (assignedQuestList.Contains(quest))
                {
                    assignedQuestList.Remove(quest);  
                    return true;
                }        
            return false;
        }
    }
}