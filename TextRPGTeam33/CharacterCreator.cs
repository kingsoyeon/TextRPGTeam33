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
        public Character Charactercreator(Character isKilledSans)
        {
            string name = "";
            do
            {
                // 캐릭터 생성 처음 화면
                Console.Clear();
                Console.WriteLine("캐릭터 생성");
                Console.WriteLine("원하시는 이름을 입력해주세요.");
                Console.Write(">> ");

                // 이름 입력
                name = Console.ReadLine();

                //if (name == null) 

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("캐릭터 생성");
                    Console.WriteLine("원하시는 이름을 입력해주세요.");
                    Console.Write(">> ");

                    Console.WriteLine($"이름 : {name}으로 진행하시겠습니까?");
                    Console.WriteLine("");
                    Console.WriteLine($"1. 진행하기");
                    Console.WriteLine($"0. 다시 입력하기");

                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine($"이름: {name}");
                        break;

                    }
                    else if (input == "0")
                    {
                        Console.Clear();
                        name = "";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다");
                        Console.ReadKey();
                    }
                }
            } while (name=="");


            Thread.Sleep(1500);

            Console.Clear();

                // 직업별 스탯 설정
                int level = 1;
                string job = "";
                int atk = 0;
                int def = 0;
                int maxHp = 0;
                int maxMp = 0;
                int gold = 1500;
                bool killSans = isKilledSans.killSans;

            while (true)
            {
                // 직업 입력
                Console.WriteLine("직업을 선택하세요");
                Console.WriteLine("");

                //   #1 탈영병
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. 탈영병 (얼음 속성)");
                Console.WriteLine("");

                //  #2 개 조련사
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2. 개 조련사 (번개 속성)");
                Console.WriteLine("");

                // #3 폭발물 산업기사
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3. 폭발물 산업기사 (불 속성)");
                Console.WriteLine("");

                // #4 소방관
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("4. 소방관 (물 속성)");
               

                Console.WriteLine("");

                // #5 튜터님
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("5. 이성언 튜터 (바위 속성)");
                Console.ResetColor();

                Console.WriteLine("");

                // #13 파피루스
                if (killSans)
                {
                    Console.WriteLine("13. 파피루스");
                }


                Console.WriteLine("원하시는 번호를 선택하세요.");
                Console.Write(">> ");

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

                    case "13":
                        job = "파피루스";
                        atk = 999;
                        def = 999;
                        maxHp = 999;
                        maxMp = 999;

                        break;


                    // 히든 직업

                    // 바위 속성
                    //case "6":
                    //    job = "파피루스";
                    //    atk = 11;
                    //    def = 6;
                    //    maxhp = 80;
                    //    maxmp = 40;

                    //    break;

                    //    스킬 없음
                    // 불 속성
                    //case "7":
                    //    job = "대머리백수";
                    //    atk = 11;
                    //    def = 6;
                    //    maxhp = 80;
                    //    maxmp = 40;

                    //    break;

                    //    수리검, 나선환
                    //    번개 속성
                    //case "8":
                    //    job = "닌자";
                    //    atk = 11;
                    //    def = 6;
                    //    maxhp = 80;
                    //    maxmp = 40;

                    //    break;

                    //    즉힐, 광전사모드
                    //    풀 속성
                    //case "9":
                    //    job = "의사";
                    //    atk = 11;
                    //    def = 6;
                    //    maxhp = 80;
                    //    maxmp = 40;

                    //    break;

                    default:
                        Console.WriteLine("잘못된 번호입니다. 다시 입력하세요.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                }

                 Console.Clear();

                     switch (job)
                {
                    case "탈영병":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("탈영병");
                        Console.ResetColor();
                        Console.WriteLine("원래 군부대에서 근무하던 병사였지만, 좀비 사태 이후 부대가 붕괴되었다.");
                        Console.WriteLine("남은 생존자들과 함께하려 했으나 군 내부의 부조리와 생존 방식에 의문을 품고 탈영했다.");
                        Console.WriteLine("지금은 부산역을 거처로 살아남기 위해 싸우고 있다.");
                        Console.WriteLine("");
                        Console.WriteLine("군사 훈련을 받았기에 기본적인 전투 스탯이 뛰어나고, 총기를 잘 다룰 수 있다.\n");
                        Console.WriteLine("");
                        break;

                    case "개 조련사":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("개 조련사");
                        Console.ResetColor();
                        Console.WriteLine("재난 이전부터 군견 훈련소에서 일하던 조련사였다.");
                        Console.WriteLine("사태 발생 후 길들인 개와 함께 도망쳤고, 이후 부산 시내에서 생존하면서 떠돌이 개들을 훈련해 동료로 삼았다.");
                        Console.WriteLine("");
                        Console.WriteLine("개와의 유대 덕분에 사냥과 추적 능력이 뛰어난 개를 활용해 전투에도 도움을 받을 수 있고, 추가 자원을 얻을 수 있다.\n");

                        break;

                    case "폭발물 산업기사 ":
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("폭발물 산업기사");
                        Console.ResetColor();
                        Console.WriteLine("과거에는 건설 및 해체 작업에서 폭약을 다루던 기술자였다.");
                        Console.WriteLine("좀비 사태 이후엔 강력한 폭발물을 활용해 길을 뚫거나, 적을 제압하는 역할을 맡고 있다.");
                        Console.WriteLine("");
                        Console.WriteLine("본인에게도 해를 입힐 만큼 폭발물은 매우 강력하다.\n");
                        break;

                    case "소방관":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("소방관");
                        Console.ResetColor();
                        Console.WriteLine("좀비 상태 발생 당시 시민들을 구하려다가 소방서가 무너지고 동료들과 떨어졌다.");
                        Console.WriteLine("이후 혼자 살아남아 생존 기술을 익히고, 여전히 사람들을 구하려고 노력 중이다.");
                        Console.WriteLine("");
                        Console.WriteLine("불길 속에서도 움직일 만큼 기본적인 스탯이 강하며, 하이드로펌프를 이용해 두 마리의 적을 동시에 상대할 수 있다.\n");
                        break;

                    case "이성언 튜터":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("이성언 튜터");
                        Console.ResetColor();
                        Console.WriteLine("내일배움캠프에서 학생들을 가르치고 있다가 사회가 붕괴한 후 혼란 속에서도 지식을 전하려 했다.");
                        Console.WriteLine("그러나 생존을 위해 더 실용적인 기술을 배워야 했고, 여러 생존자들과 만나면서 다양한 기술을 익혔다.");
                        Console.WriteLine("");
                        Console.WriteLine("높은 학습 능력과 논리적인 사고를 바탕으로, 파괴광선과 볼트태클 스킬을 익혔다.\n");
                        break;
                }

                while (true)
                {
                    
                    Console.WriteLine($"{job}을 선택하셨습니다. 이대로 진행하시겠습니까?");
                    Console.WriteLine("1. 생성하기");
                    Console.WriteLine("0. 다시 선택하기");

                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("캐릭터 생성을 완료했습니다.");
                        Console.WriteLine($"이름: {name}");
                        Console.WriteLine($"직업: {job}");
                        Thread.Sleep(2000);
                        return new Character(level, name, job, atk, def, maxHp, maxMp, gold);
                    }
                    else
                    {
                        Console.Clear() ;
                        break;
                    }
                }
            }
        }
    }
}
