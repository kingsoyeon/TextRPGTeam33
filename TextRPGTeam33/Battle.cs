using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Battle
    {
        Stage stage;
        List<Monster> monsters;
        Character player;
        int startHp;

        public bool isEnd { get; set; }

        public Battle(Character player)
        {
            this.player = player;
        }

        public void BattleStart()
        {
            stage = new Stage();
            // 전투를 시작하면 1~4마리의 몬스터가 랜덤하게 등장합니다.
            // 표시되는 순서는 랜덤입니다.
            monsters = stage.CreateMonster();
            startHp = player.Hp;

            // 중복해서 나타날 수 있습니다.

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");
                foreach (Monster m in monsters)
                {
                    Console.WriteLine($"Lv.{m.level} {m.name} HP {m.hp}");
                }
                Console.WriteLine();

                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
                Console.WriteLine($"HP {player.Hp}/{player.MaxHP}\n");

                Console.WriteLine("0. 나가기");
                Console.WriteLine("1. 공격\n");

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        return;
                    else if (input == 1)
                    {
                        PlayerPhase();
                        break;
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }

                if (isEnd)
                    return;
            }
        }

        private void PlayerPhase()
        {
            // 몬스터가 죽었다면 체력 대신 Dead 으로 표시됩니다.
            // 몬스터가 죽었다면 해당 몬스터에 텍스트는 전부 어두운 색으로 표시합니다.

            int i = 1;

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            foreach (Monster m in monsters)
            {
                if (m.hp <= 0) Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i} Lv.{m.level} {m.name} HP {m.hp}");
                i++;
            }
            Console.WriteLine();

            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/{player.MaxHP}\n");

            Console.WriteLine("0. 취소\n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;
                else if (input < 0 || input > i || monsters[input - 1].hp <= 0)
                    Console.WriteLine("잘못된 입력입니다");
                else
                {
                    Attack(input - 1);
                    break;
                }
            }

            if (isEnd)
                return;

            EnemyPhase();
        }

        private void Attack(int i)
        {
            // 해당 몬스터 공격
            // 몬스터의 체력에서 공격력 만큼 깍기
            // 공격력은 10%의 오차를 가지게 됩니다.
            // 오차가 소수점이라면 올림 처리합니다.

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.Name} 의 공격!");
            Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {player.Attack}]\n");

            int monsterHp = monsters[i].hp;
            Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}");
            //monsters[i].hp -= player.Attack;
            if (monsters[i].hp > 0)
                Console.WriteLine($"HP {monsterHp} -> {monsters[i].hp}\n");
            else
                Console.WriteLine($"HP {monsterHp} -> Dead\n");

            Console.WriteLine("0. 다음\n");

            Console.Write(">> ");

            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;
                else
                    Console.WriteLine("잘못된 입력입니다");
            }

            int flag = 0;
            foreach (Monster m in monsters)
            {
                if (m.hp > 0) flag = 1;
            }
            if (flag == 0) // 모든 적이 죽었다면
                BattleResult(true);
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

                Console.Clear();

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"Lv.{m.level} {m.name} 의 공격!");
                Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {m.atk}]\n");

                int playerHp = player.Hp;
                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {playerHp} -> {player.Hp}\n");

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        break;
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }

                if (player.Hp <= 0) // 플레이어가 죽었다면
                {
                    BattleResult(false);
                    break;
                }
            }
        }

        private void BattleResult(bool isWin)
        {
            isEnd = true;

            if (isWin)
            {
                Console.Clear();

                Console.WriteLine("Battle!! - Result\n");
                Console.WriteLine("Victory\n");
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");
                
                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {startHp} -> {player.Hp}\n");

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        break;
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Battle!! - Result\n");
                Console.WriteLine("You Lose\n");

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {startHp} -> Dead\n");

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                while (true)
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                        break;
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }
}