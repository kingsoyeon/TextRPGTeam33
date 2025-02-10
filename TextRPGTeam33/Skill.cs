using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public enum SkillType
    {
        GUN_FIRE,
        ATTACK_TWICE,
        BRING_ITEM,
        RANGE_ATTACK,
        HYDRO_PUMP,
        FIRE_RAY,
        BOLT_TACKLE
    }

    public class Skill
    {
        public SkillType type;
        public string name;
        public string desc;
        public int mp;
        public int atk;

        public Skill(SkillType type, string name, string desc, int mp, int atk)
        {
            this.type = type;
            this.name = name;
            this.desc = desc;
            this.mp = mp;
            this.atk = atk;
        }
    }
}
