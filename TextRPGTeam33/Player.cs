using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Player
    {
        // 프로퍼티 생성
        public int Level { get; }
        public String Name { get; set; }
        public string Job { get; }

        
        public int Attack { get; }
        public int PlusAttack { get; set; }


        public int Defense { get; }
        public int PlusDefense { get; set; }

        public int Hp { get; }
        public int MaxHP { get; }
        public int Gold { get; set; }

        public int DungeonClearCount { get; set; }


        
        public Player(int level, string name, string job, int atk, int def, int maxHp, int gold)
        {
            Name = name;
            Job = "전사";
            Level = level;
            Attack = atk;
            PlusAttack = 0;
            Defense = def;
            PlusDefense = 0;
            Gold = gold;
            Hp = maxHp;
            MaxHP = maxHp;
            DungeonClearCount = 0;

        }
    }
}
