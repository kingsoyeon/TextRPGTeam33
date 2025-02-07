﻿using System;
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
        Random rand;
        int startHp;
        int startMp;

        public bool isEnd { get; set; }

        public Battle(Character player)
        {
            rand = new Random();
            this.player = player;
        }

        public void BattleStart()
        {
            stage = new Stage(player);
            // 전투를 시작하면 1~4마리의 몬스터가 랜덤하게 등장합니다.
            // 표시되는 순서는 랜덤입니다.
            monsters = stage.CreateMonster();
            startHp = player.Hp;
            startMp = player.Mp;

            // 중복해서 나타날 수 있습니다.

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

                Console.WriteLine("원하시는 행동을 입력해주세요");
                Console.Write(">> ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        PlayerPhase();
                        break;
                    }
                    else if (input == "2")
                    {
                        ChooseSkill();
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
                if (m.hp <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i} Lv.{m.level} {m.name} Dead");
                }
                else
                {
                    Console.WriteLine($"{i} Lv.{m.level} {m.name} HP {m.hp}");
                }

                Console.ResetColor();
                i++;
            }
            Console.WriteLine();

            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/{player.MaxHP}");
            Console.WriteLine($"MP {player.Mp}/{player.MaxMp}\n");

            Console.WriteLine("0. 취소\n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    int index = int.Parse(input) - 1;
                    if (input == "0")
                        return;
                    else if (index >= 0 && index < monsters.Count && monsters[index].hp > 0)
                    {
                        Attack(index);
                        break;
                    }
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }
                catch
                {
                    Console.WriteLine("잘못된 입력입니다");
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
            int range = (int)MathF.Ceiling((float)player.Attack * 0.1f);
            int playerAtk = rand.Next(player.Attack - range, player.Attack + range);

            int probability = rand.Next(0, 100);
            int monsterHp = monsters[i].hp;

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.Name} 의 공격!");
            if (probability < 15)
            {
                playerAtk = (int)MathF.Ceiling((float)playerAtk * 1.6f);
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}] - 치명타 공격!!\n");
            }
            else if (probability < 25)
            {
                playerAtk = 0;
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");
            }
            else
            {
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}]\n");
            }

            monsters[i].hp -= playerAtk;
            Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}");
            if (monsters[i].hp > 0)
                Console.WriteLine($"HP {monsterHp} -> {monsters[i].hp}\n");
            else
            {
                monsters[i].hp = 0;
                Console.WriteLine($"HP {monsterHp} -> Dead\n");
            }

            Console.WriteLine("0. 다음\n");

            Console.Write(">> ");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0")
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

        private void ChooseSkill()
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

            Console.WriteLine("1. 알파 스트라이크 - MP 10");
            Console.WriteLine("    공격력 * 2 로 하나의 적을 공격합니다.");
            Console.WriteLine("2. 더블 스트라이크 - MP 15");
            Console.WriteLine("    공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.");
            Console.WriteLine("0. 취소\n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "1")
                {
                    UseSkill(1);
                    break;
                }
                else if (input == "2")
                {
                    UseSkill(2);
                    break;
                }
                else if (input == "0")
                    return;
                else
                    Console.WriteLine("잘못된 입력입니다");
            }

            if (isEnd)
                return;

            EnemyPhase();
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

                Random rand = new Random();
                bool isDodge = rand.Next(0, 101) < 10;

                Console.Clear();

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"Lv.{m.level} {m.name} 의 공격!");
                Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {m.atk}]\n");

                int playerHp = player.Hp;
                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                player.Hp -= m.atk;
                if (player.Hp < 0) player.Hp = 0;
                Console.WriteLine($"HP {playerHp} -> {player.Hp}\n");

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "0")
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

        private void UseSkill(int skill)
        {
            if (player.Mp <= 0) return;

            int i = 0;
            int j = 0;
            int playerAtk = 0;

            while (true)
            {
                if (monsters.Count <= 1)
                {
                    i = 0;
                    i = 0;
                    break;
                }
                i = rand.Next(0,monsters.Count);
                j = rand.Next(0,monsters.Count);
                if (monsters[i].hp > 0 && i != j && monsters[j].hp > 0)
                    break;
            }

            if (skill == 1) playerAtk = player.Attack * 2;
            else if (skill == 2) playerAtk = (int)MathF.Round(player.Attack * 1.5f);
            int monsterHp = monsters[i].hp;

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.Name} 의 스킬!");
            if (skill == 1)
            {
                Console.WriteLine("알파 스트라이크");
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}]\n");
                monsters[i].hp -= playerAtk;

                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}");
                if (monsters[i].hp > 0)
                    Console.WriteLine($"HP {monsterHp} -> {monsters[i].hp}\n");
                else
                {
                    monsters[i].hp = 0;
                    Console.WriteLine($"HP {monsterHp} -> Dead\n");
                }

                player.Mp -= 10;
            }
            else if (skill == 2)
            {
                Console.WriteLine("더블 스트라이크");
                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}]\n");
                Console.WriteLine($"Lv.{monsters[j].level} {monsters[j].name} 을(를) 맞췄습니다. [데미지 : {playerAtk}]\n");
                monsters[i].hp -= playerAtk;
                monsters[j].hp -= playerAtk;

                Console.WriteLine($"Lv.{monsters[i].level} {monsters[i].name}");
                if (monsters[i].hp > 0)
                    Console.WriteLine($"HP {monsterHp} -> {monsters[i].hp}\n");
                else
                {
                    monsters[i].hp = 0;
                    Console.WriteLine($"HP {monsterHp} -> Dead\n");
                }

                Console.WriteLine($"Lv.{monsters[j].level} {monsters[j].name}");
                if (monsters[j].hp > 0)
                    Console.WriteLine($"HP {monsterHp} -> {monsters[j].hp}\n");
                else
                {
                    monsters[j].hp = 0;
                    Console.WriteLine($"HP {monsterHp} -> Dead\n");
                }

                player.Mp -= 15;
            }
            if (player.Mp < 0) player.Mp = 0;

            Console.WriteLine("0. 다음\n");

            Console.Write(">> ");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "0")
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

        private void BattleResult(bool isWin)
        {
            isEnd = true;

            if (isWin)
            {
                Console.WriteLine("MP를 10만큼 회복합니다");
                player.Mp += 10;

                Console.Clear();

                Console.WriteLine("Battle!! - Result\n");
                Console.WriteLine("Victory\n");
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.\n");

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {startHp} -> {player.Hp}\n");
                Console.WriteLine($"MP {startMp} -> {player.Mp}\n");

                Console.WriteLine("0. 다음\n");

                Console.Write(">> ");

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "0")
                    {
                        stage.StageClear(monsters);
                        Console.WriteLine("보상이 지급됩니다");
                        Thread.Sleep(1000);
                        break;
                    }
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
                    string input = Console.ReadLine();
                    if (input == "0")
                        break;
                    else
                        Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }
}