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

            Console.WriteLine("Battle!!\n\n");
            // 나중에 foreach로 출력
            Console.WriteLine("Lv.2 미니언  HP 15");
            Console.WriteLine("Lv.5 대포미니언 HP 25");
            Console.WriteLine("Lv.3 공허충 HP 10\n\n\n");

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

            Console.WriteLine("Battle!!\n\n");
            // 나중에 foreach로 출력
            Console.WriteLine($"{i++} Lv.2 미니언  HP 15");
            Console.WriteLine($"{i++} Lv.5 대포미니언 HP 25");
            Console.WriteLine($"{i} Lv.3 공허충 HP 10\n\n\n");

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
                    return;
                else if (input < 0 || input > i)
                    Console.WriteLine("잘못된 입력입니다");
                else
                {
                    // 전투 진행
                    break;
                }
            }
        }

        public void EnemyPhase()
        {

        }

        public void BattleResult()
        {

        }
    }
}
