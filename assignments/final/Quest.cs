namespace AdventurerGuild 
{
    public class Quest
    {
        public string Name { get; set; }
        public string Discription { get; set; } = string.Empty;
        public QuestDifficulty Difficulty { get; set; }
        public QuestType Type { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Repeatable { get; set; } = false;

        public Quest(string name, string? discription, QuestDifficulty difficulty, QuestType questType, bool? repeatable)
        {
            Name = name;
            if (discription != string.Empty || discription != null)
                Discription = discription;
            Difficulty = difficulty;
            Type = questType;
            if (repeatable != null)
                Repeatable = (bool)repeatable;
        }

        public override string ToString()
        {
            return $"{Name}\n{Discription}\n{(Repeatable ? "Repeatable " : "")}{Type}: {Difficulty}";
        }
    }

    public enum QuestType
    {
        Hunt,
        Gather,
        Investigate,
        Transport,
        Guard,
        Service
    }
    public enum QuestDifficulty
    {
        Diamond,
        Gold,
        Silver,
        Bronze,
        Iron,
        Copper,
        Wood
    }
}