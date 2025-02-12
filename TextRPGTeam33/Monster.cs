namespace TextRPGTeam33
{
    public class Monster
    {
        public string name { get; }
        public int level { get; }
        public int hp { get; set; }
        public int maxHp { get; set; }
        public int atk { get; }
        public bool isBoss { get; }
        public Monster(string name, int level, int hp, int atk, bool isBoss)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
            this.maxHp = hp;
            this.atk = atk;
            this.isBoss = isBoss;
        }
    }
}
