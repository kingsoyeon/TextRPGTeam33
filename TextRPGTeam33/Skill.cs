using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Skill
    {
        public string name;
        public string desc;
        public int mp;
        public int atk;

        public Skill(string name, string desc, int mp, int atk)
        {
            this.name = name;
            this.desc = desc;
            this.mp = mp;
            this.atk = atk;
        }
    }
}
