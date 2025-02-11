using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class SkillManager
    {
        Character player;
        List<Skill> skills;
        List<Monster> monsters;
        Random rand;
        public int skillCount;
        int bullet;
        int maxBullet;

        public SkillManager(Character player, List<Monster> monsters)
        {
            this.player = player;
            skills = new List<Skill>();
            this.monsters = monsters;
            rand = new Random();
            maxBullet = 3;
            bullet = maxBullet;

            switch (player.Job)
            {
                case "탈영병":
                    skills.Add(new Skill(SkillType.GUN_SHOT, "총 사격", "사격을 통해 공격합니다", 4, 10));
                    skills.Add(new Skill(SkillType.GUN_RELOAD, "재장전", "재장전합니다", 3, 0));
                    skills.Add(new Skill(SkillType.GRENADE, "수류탄 투척", "수류탄을 던져 폭파합니다", 20, 5));
                    break;
                case "개 조련사":
                    skills.Add(new Skill(SkillType.ATTACK_TWICE, "두번 공격", "개와 함께 공격합니다", 6, 8));
                    skills.Add(new Skill(SkillType.BRING_ITEM, "아이템 물어오기", "아이템을 물어오게 시킵니다", 3, 0));
                    break;
                case "폭발물 산업기사":
                    skills.Add(new Skill(SkillType.RANGE_ATTACK, "범위 공격", "본인을 포함한 모두에게 데미지를 입힙니다", 25, 5));
                    skills.Add(new Skill(SkillType.BOMB_UPGRADE, "폭탄 강화", "폭탄을 강화합니다", 3, 0));
                    break;
                case "소방관":
                    skills.Add(new Skill(SkillType.HYDRO_PUMP, "하이드로펌프", "랜덤한 대상 2명을 공격합니다", 15, 8));
                    skills.Add(new Skill(SkillType.BACKDRAFT, "백드래프트", "폭발적인 산소 공급으로 순간적인 충격파 생성", 20, 5));
                    break;
                case "이성언 튜터":
                    skills.Add(new Skill(SkillType.FIRE_RAY, "파괴광선", "파괴광선을 발사합니다", 7, 10));
                    skills.Add(new Skill(SkillType.BOLT_TACKLE, "볼트태클", "볼트태클을 구사합니다", 6, 7));
                    break;
                case "파피루스":
                    break;
                case "대머리백수":
                    break;
                case "닌자":
                    skills.Add(new Skill(SkillType.ATTACK_TWICE, "수리검", "수리검을 던집니다", 5, 10));
                    skills.Add(new Skill(SkillType.ATTACK_TWICE, "나선환", "나선환을 이용해 공격합니다", 10, 15));
                    break;
                case "의사":
                    skills.Add(new Skill(SkillType.ATTACK_TWICE, "즉시회복", "즉시 회복합니다", 10, 10));
                    skills.Add(new Skill(SkillType.ATTACK_TWICE, "광전사모드", "광전사가 되어 공격합니다", 10, 10));
                    break;
            }
        }

        public int ChooseSkill()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");
                foreach (Monster m in monsters)
                {
                    if (m.hp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"Lv.{m.level} {m.name} Dead");
                    }
                    else
                    {
                        Console.WriteLine($"Lv.{m.level} {m.name} HP {m.hp}");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();

                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHP}");
                Console.WriteLine($"MP {player.Mp}/{player.MaxMp}\n");

                int i = 1;
                foreach (Skill s in skills)
                {
                    Console.WriteLine($"{i++}. {s.name} - MP {s.mp} | ATK {s.atk}");
                    Console.WriteLine($"   {s.desc}");
                }
                Console.WriteLine("0. 취소\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input >= 0 && input <= i - 1)
                        return input;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                }
            }
        }

        public int UseSkill(int i)
        {
            int index = 0;
            int index2 = 0;
            int monster1Hp = 0;
            int monster2Hp = 0;
            int[] monsterHp = new int[10];
            int playerHp = 0;
            int cnt = 0;
            List<Monster> target;
            target = new List<Monster>();

            switch (skills[i].type) // 스킬 종류에 따라 효과 적용 (제작 중)
            {
                case SkillType.GUN_SHOT:
                case SkillType.ATTACK_TWICE:
                case SkillType.FIRE_RAY:
                case SkillType.BOLT_TACKLE:
                    index = ChooseTarget(i);
                    if (index == -1) return -1;
                    if (skills[i].type == SkillType.GUN_SHOT)
                    {
                        bullet--;
                        if (bullet < 0) bullet = 0;
                    }
                    monster1Hp = monsters[index].hp;
                    monsters[index].hp -= skills[i].atk;
                    if (monsters[index].hp < 0) monsters[index].hp = 0;
                    break;
                case SkillType.GUN_RELOAD:
                    bullet = maxBullet;
                    break;
                case SkillType.BRING_ITEM:
                    skillCount++;
                    break;
                case SkillType.GRENADE:
                case SkillType.RANGE_ATTACK:
                case SkillType.BACKDRAFT:
                    playerHp = player.Hp;
                    player.Hp -= skills[i].atk;
                    if (player.Hp < 0) player.Hp = 0;
                    int j = 0;
                    foreach (Monster m in monsters)
                    {
                        if (m.hp <= 0)
                            continue;

                        target.Add(m);
                        monsterHp[j++] = m.hp;
                        m.hp -= skills[i].atk;
                        if (m.hp < 0) m.hp = 0;
                    }
                    break;
                case SkillType.BOMB_UPGRADE:
                    skills[0].atk += 3;
                    break;
                case SkillType.HYDRO_PUMP:
                    cnt = 0;
                    foreach (Monster m in monsters)
                    {
                        if (m.hp > 0)
                            cnt++;
                    }

                    index = rand.Next(0, monsters.Count);
                    while (true)
                    {
                        if (monsters[index].hp == 0)
                            index = rand.Next(0, monsters.Count);
                        else
                            break;
                    }
                    monster1Hp = monsters[index].hp;

                    monsters[index].hp -= skills[i].atk;
                    if (monsters[index].hp < 0) monsters[index].hp = 0;

                    if (cnt > 1)
                    {
                        index2 = rand.Next(0, monsters.Count);
                        while (true)
                        {
                            if (monsters[index2].hp == 0 || index == index2)
                                index2 = rand.Next(0, monsters.Count);
                            else
                                break;
                        }
                        monster2Hp = monsters[index2].hp;

                        monsters[index2].hp -= skills[i].atk;
                        if (monsters[index2].hp < 0) monsters[index2].hp = 0;
                    }
                    break;
            }
            if (player.Mp >= skills[i].mp) player.Mp -= skills[i].mp;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"{player.Name} 의 {skills[i].name}!\n");
                switch (skills[i].type)
                {
                    case SkillType.ATTACK_TWICE:
                        for (int a = 0; a < 2; a++)
                        {
                            Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk / 2}]");
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name}");
                        if (monsters[index].hp > 0)
                            Console.WriteLine($"HP {monster1Hp} -> {monsters[index].hp}\n");
                        else
                            Console.WriteLine($"HP {monster1Hp} -> Dead\n");
                        break;
                    case SkillType.GUN_SHOT:
                    case SkillType.FIRE_RAY:
                    case SkillType.BOLT_TACKLE:
                        Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                        Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name}");
                        if (monsters[index].hp > 0)
                            Console.WriteLine($"HP {monster1Hp} -> {monsters[index].hp}\n");
                        else
                            Console.WriteLine($"HP {monster1Hp} -> Dead\n");
                        break;
                    case SkillType.BRING_ITEM:
                        Console.WriteLine("아이템을 물어왔습니다\n");

                        Console.WriteLine("골드 획득량이 10% 증가합니다");
                        Console.WriteLine("아이템 획득 확률이 10% 증가합니다\n");
                        break;
                    case SkillType.GRENADE:
                    case SkillType.RANGE_ATTACK:
                    case SkillType.BACKDRAFT:
                        Console.WriteLine($"Lv.{player.Level} {player.Name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                        Console.WriteLine($"Lv.{player.Level} {player.Name}");
                        if (player.Hp > 0)
                            Console.WriteLine($"HP {playerHp} -> {player.Hp}\n");
                        else
                            Console.WriteLine($"HP {playerHp} -> Dead\n");

                        int j = 0;
                        foreach (Monster m in target)
                        {
                            Console.WriteLine($"Lv.{m.level} {m.name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                            Console.WriteLine($"Lv.{m.level} {m.name}");
                            if (m.hp > 0)
                                Console.WriteLine($"HP {monsterHp[j++]} -> {m.hp}\n");
                            else
                                Console.WriteLine($"HP {monsterHp[j++]} -> Dead\n");
                        }
                        break;
                    case SkillType.BOMB_UPGRADE:
                        Console.WriteLine("폭탄을 강화합니다\n");

                        Console.WriteLine("폭탄의 공격력이 3 증가합니다\n");
                        break;
                    case SkillType.HYDRO_PUMP:
                        Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                        Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name}");
                        if (monsters[index].hp > 0)
                            Console.WriteLine($"HP {monster1Hp} -> {monsters[index].hp}\n");
                        else
                            Console.WriteLine($"HP {monster1Hp} -> Dead\n");

                        if (cnt > 1)
                        {
                            Console.WriteLine($"Lv.{monsters[index2].level} {monsters[index2].name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                            Console.WriteLine($"Lv.{monsters[index2].level} {monsters[index2].name}");
                            if (monsters[index].hp > 0)
                                Console.WriteLine($"HP {monster2Hp} -> {monsters[index2].hp}\n");
                            else
                                Console.WriteLine($"HP {monster2Hp} -> Dead\n");
                        }
                        break;
                }

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                string input = Console.ReadLine();
                if (input == "0")
                    break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                }
            }

            int flag = 0;
            foreach (Monster m in monsters)
            {
                if (m.hp > 0) flag = 1;
            }
            if (flag == 0) // 모든 적이 죽었다면
                return 1;

            return 0;
        }

        private int ChooseTarget(int index)
        {
            // 몬스터가 죽었다면 체력 대신 Dead 으로 표시됩니다.
            // 몬스터가 죽었다면 해당 몬스터에 텍스트는 전부 어두운 색으로 표시합니다.

            while (true)
            {
                int i = 1;

                Console.Clear();

                Console.WriteLine("Battle!!\n");
                foreach (Monster m in monsters)
                {
                    if (m.hp <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"{i++} Lv.{m.level} {m.name} Dead");
                    }
                    else
                    {
                        Console.WriteLine($"{i++} Lv.{m.level} {m.name} HP {m.hp}");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();

                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHP}");
                Console.WriteLine($"MP {player.Mp}/{player.MaxMp}\n");

                if (skills[index].type == SkillType.GUN_SHOT)
                {
                    if (bullet <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("남은 총알이 없습니다");
                        Thread.Sleep(1000);
                        return -1;
                    }
                    Console.WriteLine($"남은 총알 개수 : {bullet}");
                }
                Console.WriteLine("0. 취소\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        return -1;
                    else if (input > 0 && input <= monsters.Count && monsters[input - 1].hp > 0)
                        return input - 1;
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
