using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class CharacterCreator
    {
        public Character Charactercreator()
        {
            // 캐릭터 생성 처음 화면
            Console.Clear();
            Console.WriteLine("캐릭터 생성");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">> ");
            
            // 이름 입력
            string name = Console.ReadLine();
            
                if (name == null) {  }

                Console.WriteLine($"이름 : {name}");

                Console.WriteLine("");

                // 직업별 스탯 설정
                int level = 1;
                string job = "";
                int atk = 0;
                int def = 0;
                int maxHp = 0;
                int maxMp = 0;
                int gold = 1500;

            while (true)
            {
                // 직업 입력
                Console.WriteLine("직업을 선택하세요");
                Console.WriteLine("1. 탈영병");
                Console.WriteLine("2. 개 조련사");
                Console.WriteLine("3. 폭발물 산업기사");
                Console.WriteLine("4. 소방관");
                Console.WriteLine("5. 이성언 튜터");
                Console.WriteLine("");
                Console.WriteLine("원하시는 번호를 선택하세요.");
                string selectJob = Console.ReadLine();


                switch (selectJob)
                {
                    // 기본스탯 높음
                    // 얼음 속성
                    case "1":
                        job = "탈영병";
                        atk = 10;
                        def = 5;
                        maxHp = 100;
                        maxMp = 30;

                        break;

                    // 두번 공격, 아이템 물어 오기
                    // 번개 속성
                    case "2":
                        job = "개 조련사";
                        atk = 8;
                        def = 7;
                        maxHp = 110;
                        maxMp = 30;

                        break;

                    // 범위 공격, 본인도 데미지
                    // 불 속성
                    case "3":
                        job = "폭발물 산업기사";
                        atk = 6;
                        def = 4;
                        maxHp = 70;
                        maxMp = 70;

                        break;

                    // 하이드로펌프, 2명 공격
                    // 물 속성
                    case "4":
                        job = "소방관";
                        atk = 6;
                        def = 5;
                        maxHp = 80;
                        maxMp = 60;

                        break;

                    // 파괴광선, 볼트태클
                    // 바위속성
                    case "5":
                        job = "이성언 튜터";
                        atk = 11;
                        def = 6;
                        maxHp = 80;
                        maxMp = 40;

                        break;


                    // 히든 직업

                    // 바위 속성
                    case "6":
                        job = "파피루스";
                        atk = 11;
                        def = 6;
                        maxHp = 80;
                        maxMp = 40;

                        break;

                    // 스킬 없음
                    // 불 속성
                    case "7":
                        job = "대머리백수";
                        atk = 11;
                        def = 6;
                        maxHp = 80;
                        maxMp = 40;

                        break;

                    // 수리검, 나선환
                    // 번개 속성
                    case "8":
                        job = "닌자";
                        atk = 11;
                        def = 6;
                        maxHp = 80;
                        maxMp = 40;

                        break;

                    // 즉힐, 광전사모드
                    // 풀 속성
                    case "9":
                        job = "의사";
                        atk = 11;
                        def = 6;
                        maxHp = 80;
                        maxMp = 40;

                        break;

                    default:
                        Console.WriteLine("잘못된 번호입니다. 다시 입력하세요.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;


                }
                break;
            }
                return new Character(level, name, job, atk, def, maxHp, maxMp, gold);

        }
    }
}
