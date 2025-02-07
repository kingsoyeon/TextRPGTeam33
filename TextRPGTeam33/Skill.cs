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
        string name;
        int mp;
        int atk;

        public Skill(string name, int mp, int atk)
        {
            this.name = name;
            this.mp = mp;
            this.atk = atk;
        }
    }
}
