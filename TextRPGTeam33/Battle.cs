using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Battle
    {
        Stage stage;
        List<Monster> monsters;
        Character player;
        List<Skill> skills;
        Random rand;
        int startHp;
        int startMp;

        public bool isEnd { get; set; }

        public Battle(Character player)
        {
            // 전투를 시작하면 1~4마리의 몬스터가 랜덤하게 등장합니다.
            // 표시되는 순서는 랜덤입니다.
            // 중복해서 나타날 수 있습니다.
            stage = new Stage(player);
            monsters = stage.CreateMonster();
            this.player = player;
            skills = new List<Skill>();
            rand = new Random();
            startHp = player.Hp;
            startMp = player.Mp;

            switch(player.Job)
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

        public void BattleStart()
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

                Console.WriteLine("1. 공격");
                Console.WriteLine("2. 스킬\n");
                Console.WriteLine("0. 나가기");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        break;
                    else if (input == 1)
                    {
                        int sel = PlayerPhase();
                        if (sel == 0)
                            continue;
                        else
                            Attack(sel - 1);
                    }
                    else if (input == 2)
                    {
                        int sel = ChooseSkill();
                        if (sel == 0)
                            continue;
                        else
                            UseSkill(sel - 1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (isEnd)
                    {
                        BattleResult();
                        break;
                    }

                    EnemyPhase();

                    if (isEnd)
                    {
                        BattleResult();
                        break;
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

        private int PlayerPhase()
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

                Console.WriteLine("0. 취소\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        return 0;
                    else if (input > 0 && input <= monsters.Count && monsters[input - 1].hp > 0)
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

        private void Attack(int i)
        {
            // 해당 몬스터 공격
            // 몬스터의 체력에서 공격력 만큼 깍기
            // 공격력은 10%의 오차를 가지게 됩니다.
            // 오차가 소수점이라면 올림 처리합니다.

            int range = (int)MathF.Ceiling((float)player.Attack * 0.1f);
            int playerAtk = rand.Next(player.Attack - range, player.Attack + range);

            int probability = rand.Next(0, 100);
            if (probability < 15)
                playerAtk = (int)MathF.Ceiling((float)playerAtk * 1.6f);
            else if (probability < 25)
                playerAtk = 0;

            int monsterHp = monsters[i].hp;
            monsters[i].hp -= playerAtk;
            if (monsters[i].hp < 0) monsters[i].hp = 0;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"{player.Name} 의 공격!");
                if (probability < 15)
                    Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}] - 치명타 공격!!\n");
                else if (probability < 25)
                    Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");
                else
                    Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}]\n");

                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}");
                if (monsters[i].hp > 0)
                    Console.WriteLine($"HP {monsterHp} -> {monsters[i].hp}\n");
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
                isEnd = true;
        }

        private void EnemyPhase()
        {
            // 위에 표시된 몬스터부터 공격합니다.
            // Dead 상태인 몬스터는 공격하지 않습니다.
            // 다음을 누르면 그 다음 몬스터의 공격이 계속 됩니다.
            // 몬스터의 차례가 끝나면 플레이어의 차례로 돌아옵니다.

            foreach (Monster m in monsters)
            {
                if (m.hp <= 0)
                    continue;

                int playerHp = player.Hp;
                player.Hp -= m.atk;
                if (player.Hp < 0) player.Hp = 0;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!!\n");
                    Console.WriteLine($"Lv.{m.level} {m.name} 의 공격!");
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {m.atk}]\n");

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {playerHp} -> {player.Hp}\n");

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

                if (player.Hp <= 0) // 플레이어가 죽었다면
                {
                    isEnd = true;
                    break;
                }
            }
        }

        private int ChooseSkill()
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

        private void UseSkill(int i)
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
                isEnd = true;
        }

        private void BattleResult()
        {
            if (player.Hp > 0)
            {
                player.Mp += 10;
                if (player.Mp > player.MaxMp)
                    player.Mp = player.MaxMp;
                Console.Clear();
                Console.WriteLine("MP를 10만큼 회복합니다");
                Thread.Sleep(1000);

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!! - Result\n");
                    Console.WriteLine("Victory\n");
                    Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");

                    Console.WriteLine("0. 다음\n");

                    Console.Write(">> ");

                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        Console.Clear();
                        stage.StageClear(monsters, startHp);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다");
                        Thread.Sleep(1000);
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!! - Result\n");
                    Console.WriteLine("You Lose\n");

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {startHp} -> Dead\n");

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
            }
        }
    }
}