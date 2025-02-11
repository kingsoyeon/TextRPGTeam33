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
        SkillManager skillManager;
        Potion potion;
        Random rand;
        int startHp;
        int startMp;

        public bool isEnd { get; set; }

        public Battle(Character player, Potion potion)
        {
            // 전투를 시작하면 1~4마리의 몬스터가 랜덤하게 등장합니다.
            // 표시되는 순서는 랜덤입니다.
            // 중복해서 나타날 수 있습니다.
            stage = new Stage(player);
            monsters = stage.CreateMonster();
            this.player = player;
            skillManager = new SkillManager(player, monsters);
            this.potion = potion;
            rand = new Random();
            startHp = player.Hp;
            startMp = player.Mp;
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
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 포션 사용\n");
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
                        int sel = skillManager.ChooseSkill();
                        if (sel == 0)
                            continue;
                        else
                        {
                            int key = skillManager.UseSkill(sel - 1);
                            if (key == -1)
                                continue;
                            else if (key == 0)
                                isEnd = false;
                            else if (key == 1)
                                isEnd = true;
                        }
                    }
                    else if (input == 3)
                    {
                        int sel = potion.DisplayPotion();

                        if (sel == 0)
                            continue;
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
                int playerDef = (int)Math.Ceiling((float)player.Defense * 0.1f);
                player.Hp -= m.atk - playerDef;
                if (player.Hp < 0) player.Hp = 0;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!!\n");
                    Console.WriteLine($"Lv.{m.level} {m.name} 의 공격!");
                    Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {m.atk}]\n");

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"{playerDef} 만큼 방어했습니다");
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

        private void BattleResult()
        {
            if (player.Hp > 0)
            {
                player.Mp += 10;
                if (player.Mp > player.MaxMp)
                    player.Mp = player.MaxMp;

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("Battle!! - Result\n");
                    Console.WriteLine("Victory\n");
                    Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");

                    Console.WriteLine("MP를 10만큼 회복합니다\n");

                    Console.WriteLine("0. 다음\n");

                    Console.Write(">> ");

                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        Console.Clear();
                        stage.StageClear(monsters, startHp, skillManager.skillCount);
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