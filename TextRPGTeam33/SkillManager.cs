using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public SkillManager(Character player, List<Monster> monsters)
        {
            this.player = player;
            skills = new List<Skill>();
            this.monsters = monsters;
            rand = new Random();

            switch (player.Job)
            {
                case "탈영병":
                    break;
                case "개 조련사":
                    skills.Add(new Skill("두번 공격", "개와 함께 공격합니다", 10, 10));
                    skills.Add(new Skill("아이템 물어오기", "아이템을 물어오게 시킵니다", 5, 0));
                    break;
                case "폭발물 산업기사":
                    skills.Add(new Skill("범위 공격", "본인을 포함한 모두에게 데미지를 입힙니다", 30, 10));
                    break;
                case "소방관":
                    skills.Add(new Skill("하이드로펌프", "랜덤한 대상 2명을 공격합니다", 20, 10));
                    break;
                case "이성언 튜터":
                    skills.Add(new Skill("파괴광선", "파괴광선을 발사합니다", 10, 10));
                    skills.Add(new Skill("볼트태클", "볼트태클을 구사합니다", 20, 20));
                    break;
                case "파피루스":
                    break;
                case "대머리백수":
                    break;
                case "닌자":
                    skills.Add(new Skill("수리검", "수리검을 던집니다", 5, 10));
                    skills.Add(new Skill("나선환", "나선환을 이용해 공격합니다", 10, 15));
                    break;
                case "의사":
                    skills.Add(new Skill("즉시회복", "즉시 회복합니다", 10, 10));
                    skills.Add(new Skill("광전사모드", "광전사가 되어 공격합니다", 10, 10));
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
                    Console.WriteLine($"{i++}. {s.name} - MP {s.mp}");
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

        public bool UseSkill(int i)
        {
            switch (skills[i].name) // 스킬 종류에 따라 효과 적용 (제작 중)
            {
                case "두번 공격":
                    break;
                case "범위 공격":
                    break;
                case "하이드로펌프":
                    break;
                case "파괴광선":
                    break;
                case "볼트태클":
                    break;
            }

            // 기본 스킬 메커니즘 예시
            int index = rand.Next(0, monsters.Count);
            while (true)
            {
                if (monsters[index].hp == 0)
                    index = rand.Next(0, monsters.Count);
                else
                    break;
            }
            int monsterHp = monsters[index].hp;

            monsters[index].hp -= skills[i].atk;
            if (monsters[index].hp < 0) monsters[index].hp = 0;
            if (player.Mp >= skills[i].mp) player.Mp -= skills[i].mp;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"{player.Name} 의 {skills[i].name}!");
                Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name} 을(를) 맞췄습니다. [데미지 : {skills[i].atk}]\n");

                Console.WriteLine($"Lv.{monsters[index].level} {monsters[index].name}");
                if (monsters[index].hp > 0)
                    Console.WriteLine($"HP {monsterHp} -> {monsters[index].hp}\n");
                else
                    Console.WriteLine($"HP {monsterHp} -> Dead\n");

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
                return true;

            return false;
        }
    }
}
