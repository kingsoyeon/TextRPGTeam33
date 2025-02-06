namespace TextRPGTeam33
{
    public class Monster
    {
        public string name { get; }
        public int level { get; }
        public int hp { get; }
        public int atk { get; }
        public Monster(string name, int level, int hp, int atk)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.atk = atk;
        }
    }
}
