using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Battle
    {
        public void BattleStart()
        {
            // 전투를 시작하면 1~4마리의 몬스터가 랜덤하게 등장합니다.
            // 표시되는 순서는 랜덤입니다.

            // 중복해서 나타날 수 있습니다.

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            // 나중에 foreach로 출력
            Console.WriteLine("Lv.2 미니언  HP 15");
            Console.WriteLine("Lv.5 대포미니언 HP 25");
            Console.WriteLine("Lv.3 공허충 HP 10\n");

            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.1  Chad (전사)");
            Console.WriteLine("HP 100/100\n");

            Console.WriteLine("1. 공격\n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Attack();
                    EnemyPhase();
                }
                else
                    Console.WriteLine("잘못된 입력입니다");
            }
        }

        public void Attack()
        {
            int i = 1;

            Console.Clear();

            Console.WriteLine("Battle!!\n");
            // 나중에 foreach로 출력
            Console.WriteLine($"{i++} Lv.2 미니언  HP 15");
            Console.WriteLine($"{i++} Lv.5 대포미니언 HP 25");
            Console.WriteLine($"{i} Lv.3 공허충 HP 10\n");

            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv.1  Chad (전사)");
            Console.WriteLine("HP 100/100\n");

            Console.WriteLine("0. 취소\n");

            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">> ");
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;
                else if (input < 0 || input > i)
                    Console.WriteLine("잘못된 입력입니다");
                else
                {
                    AttackProcess();
                    break;
                }
            }
        }

        private void AttackProcess()
        {
            // 해당 몬스터 공격
            // 몬스터의 체력에서 공격력 만큼 깍기
            // 공격력은 10%의 오차를 가지게 됩니다.
            // 오차가 소수점이라면 올림 처리합니다.

            // 몬스터가 죽었다면 체력 대신 Dead 으로 표시됩니다.
            // 몬스터가 죽었다면 해당 몬스터에 텍스트는 전부 어두운 색으로 표시합니다.


        }

        public void EnemyPhase()
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n");
            Console.WriteLine("Char 의 공격!");
            Console.WriteLine("Lv.3 공허충 을(를) 맞췄습니다. [데미지 : 10]\n");

            Console.WriteLine("Lv.3 공허충");
            Console.WriteLine("HP 10 -> Dead\n");

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

        public void BattleResult()
        {

        }
    }
}
