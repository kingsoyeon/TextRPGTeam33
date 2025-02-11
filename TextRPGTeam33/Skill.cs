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
        //탈열병
        GUN_SHOT,
        GUN_RELOAD,
        GRENADE,
        //개조련사
        ATTACK_TWICE,
        BRING_ITEM,
        //폭발물
        RANGE_ATTACK,
        BOMB_UPGRADE,
        //소방관
        HYDRO_PUMP,
        BACKDRAFT,
        //튜터님
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
