namespace AdventurerGuild 
{
    public class Monster
    {
        public string Name { get; set; }
        public string Discription { get; set; } = string.Empty;
        public Difficulty Difficulty { get; set; }

        public Monster(string name, string? discription, Difficulty difficulty)
        {
            Name = name;
            if (discription != null)
                Discription = discription;
            Difficulty = difficulty;            
        }

        public override string ToString()
        {
            return $"{Name} - {Difficulty}\n{Discription}";
        }
    }
}