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
            Console.OutputEncoding = Encoding.UTF8;
            string name = "";
            do
            {
                // 캐릭터 생성 처음 화면
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                Console.Write("ㅁ\t");
                Console.ResetColor();
                Console.Write("원하시는 이름을 입력해주세요.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\t ㅁ");
                Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                Console.ResetColor();
                Console.Write(">> ");

                // 이름 입력
                name = Console.ReadLine();

                //if (name == null) 

                while (true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                    Console.Write("ㅁ\t");
                    Console.ResetColor();
                    Console.Write("원하시는 이름을 입력해주세요.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t ㅁ");
                    Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                    Console.ResetColor();
                    Console.Write(">> ");

                    Console.Clear();
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ"); 
                    Console.ResetColor();
                    Console.WriteLine($"\t이름 : {name}으로 진행하시겠습니까?");
                    Console.WriteLine("");
                    Console.WriteLine("\t1. 진행하기");
                    Console.WriteLine("\t0. 다시 입력하기");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(" ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ-ㅁ");
                    Console.ResetColor();
                    Console.Write(">> ");

                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"**부산역에 오신걸 환영합니다.{name}님**");
                        Console.ResetColor();
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
                bool killSans = isKilledSans.KillSans;
            
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
                    // 스킬 소비 마나 4/3/20(수류탄)
                    // 얼음 속성
                    case "1":
                        job = "탈영병";
                        atk = 9;
                        def = 4;
                        maxHp = 90;
                        maxMp = 30;

                        break;

                    // 두번 공격, 아이템 물어 오기
                    // 스킬 소비 마나 6/3
                    // 번개 속성
                    case "2":

                        job = "개 조련사";
                        atk = 4;
                        def = 9;
                        maxHp = 80;
                        maxMp = 30;

                        break;

                    // 범위 공격, 본인도 데미지
                    // 스킬 소비 마나 25/3
                    // 불 속성
                    case "3":

                        job = "폭발물 산업기사";
                        atk = 9;
                        def = 4;
                        maxHp = 70;
                        maxMp = 50;

                        break;

                    // 하이드로펌프, 2명 공격
                    // 스킬 소비 마나 15/20
                    // 물 속성
                    case "4":

                        job = "소방관";
                        atk = 8;
                        def = 7;
                        maxHp = 100;
                        maxMp = 40;

                        break;

                    // 파괴광선, 볼트태클
                    // 스킬 소비 마나 7/6
                    // 바위속성
                    case "5":

                        job = "이성언 튜터";
                        atk = 7;
                        def = 6;
                        maxHp = 80;
                        maxMp = 30;

                        break;

                    // 히든직업
                    case "13":
                        // 히든보스를 죽이지 않았는데, 13번을 입력할 시
                        if (!killSans) 
                        {
                            Console.WriteLine("...");
                            Thread.Sleep(1500);
                            Console.Clear();
                            continue;
                        }

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
                        Console.Write("                       　         QQQQQQQQQ");
                        Console.WriteLine("\t\t탈영병");
                        Console.WriteLine("                      　         QQQQQQQ");
                        Console.Write("                  　            QQQQ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t원래 군부대에서");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("               　              QQQ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t근무하던 병사였지만,");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                　            QQQ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t좀비 사태 이후");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                       　   ㅁㅇㅁㅁㅁ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t부대가 붕괴되었다.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                  　   　  ㅁㅇㅁㅁㅁ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t남은 생존자들과");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                        ㅁㅁㅇㅁㅁㅁ      　　GGGGGG");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t함께하려 했으나");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                     ㅁㅁㅁㅇㅁㅁㅁGG　　　GGGGGGGGG");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t군 내부의 부조리와");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                      ㅁ@@ㅇㅁㅁㅁㅁGG　GGGGGGGGG   G");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t생존 방식에 의문을 품고");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                     ㅁㅁㅇㅁㅁㅁㅁㅁGGGGGGGGG");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t탈영했다.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                      ㅁㅇㅁㅁㅁㅁㅁㅁGGGG");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t지금은 부산역을 거처로");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                     ㅁㅇㅁㅁㅁㅁㅁ /");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t살아남기 위해 싸우고 있다.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                    ㅁㅇㅁㅁㅁㅁ＊＊ /");
                        Console.WriteLine("");
                        Console.Write("                   ㅁㅇㅁㅁㅁㅁㅁ  ＊/");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t※ TIP");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                  ㅁㅇㅁㅁㅁㅁㅁㅁ /");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t군사 훈련을 받았기에");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                 ㅁㅇㅁㅁㅁㅁㅁㅁDDD");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t기본적인 전투 스탯이 뛰어나고,");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("                ㅁㅇㅁㅁㅁㅁㅁㅁDDDDD");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\t\t\t총기를 잘 다룰 수 있다.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("               @@@@@@@@@@   ㅁㅁ DDDDD");
                        Console.WriteLine("");
                        Console.WriteLine("              @@@@@@@@@@         DDDDDD");
                        Console.WriteLine("             @@@@@@@@@@           DDDDDD");
                        Console.WriteLine("            @@@@@@@@@@             DDDDDD");
                        Console.WriteLine("           @@@@@@@@@@              DDDDDD");
                        Console.WriteLine("          //@@@@//                 DDDD");
                        Console.WriteLine("         //@@@@//");
                        Console.WriteLine("        //  ///");
                        Console.WriteLine("       //  ///");
                        Console.WriteLine("      //  ///");
                        Console.WriteLine("   44//==///");
                        Console.WriteLine("    //==///");
                        Console.WriteLine("       ///");
                        Console.WriteLine("      ///");
                        Console.WriteLine("     ///");
                        Console.WriteLine("   ////");
                        Console.WriteLine("  ////");
                        Console.WriteLine(" ////");
                        Console.ResetColor();

                        break;

                    case "개 조련사":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("               ");
                        Console.Write("             QQQQQQQ");
                        Console.WriteLine("\t\t\t\t\t\t개 조련사");
                        Console.Write("            QQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t\t\t재난 이전부터 ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("           QQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t\t\t군견 훈련소에서");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("         QQQQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t\t\t조련사였다.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("        QQQQQQQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t\t\t사태 발생 후 ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("       QQQQQQQQQQQQ                     QQQQQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t길들인 개와 함께 도망쳤고");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("      QQQQQQQQQQ******************QQQQQQQQQQQQQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t이후 부산 시내에서 생존하면서 ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("      QQQQ,,,,,,,,,,,,,,,,,,,,,,,,,,,QQQQQQQQQQQQQQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t떠돌이 개들을 훈련해");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("       Q,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,QQQQ      QQQQ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t동료로 삼았다.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("        *,,,,,-------,,,,,,,,,,,-----------,,*");
                        Console.WriteLine("");
                        Console.Write("       *,,,,-----PP----,,,,,,,,------PP---,*");
                        Console.WriteLine("\t\t※ TIP");
                        Console.Write("       *,,,---PP---PP----,,,,,-----PP--PP-*");
                        Console.WriteLine("");
                        Console.Write("        *,,--PP-----PP------,,----PP----PP*");
                        Console.ResetColor();
                        Console.WriteLine("\t\t개와의 유대를 쌓아,");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("        *,,--PP-----PP------,,----PP----PP*");
                        Console.ResetColor();
                        Console.WriteLine("\t\t사냥과 추적 능력이");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("        *,,-------------------------------*");
                        Console.ResetColor();
                        Console.WriteLine("\t\t뛰어난 개를활용해");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("         *,------------------------------@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t전투에도 도움을 받을 수 있고,");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("          *-------$$$$$$$-----------------@&@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t추가 자원을 얻을 수 있다.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("          *-----$$$$$$$$$$$--------------..@-*");
                        Console.WriteLine("           *----$$$$$$$$$$$$$-----------..--*");
                        Console.WriteLine("           *#-------$$$$$$$$$$$$$$-----..--*                ________");
                        Console.WriteLine("          *,,##---------$$$$$$$$$$$$$$.----##*             ***********");
                        Console.WriteLine("         *,,,##--------------------------##,*             *,,***********");
                        Console.WriteLine("        *,,,,,,########################,,,,*            *,,,---**********");
                        Console.WriteLine("       *,,,,,,---------------------,,,,,,,,,*          *,,------**/*/*/*");
                        Console.WriteLine("      *,,,----------------------------------,,*       *,,--------*");
                        Console.WriteLine("     *,,,,----------------------------------,,,,*    *,,--------*");
                        Console.ResetColor();



                        break;

                    case "폭발물 산업기사":
         
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                      ※  ");
                        Console.WriteLine("\t\t\t폭발물 산업기사");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                           ※           ※");
                        Console.ResetColor();   
                        Console.WriteLine("\t과거에는");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              ※     ※※");
                        Console.ResetColor();
                        Console.WriteLine("\t\t건설 및 해체 작업에서");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              ※※※");
                        Console.ResetColor();
                        Console.WriteLine("\t\t폭약을 다루던");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                           ※※※※※※※※※   ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t기술자였다.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                             ※※※※※");
                        Console.ResetColor();
                        Console.WriteLine("\t\t좀비 사태 이후엔");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                          ※※  //   ※");
                        Console.ResetColor();
                        Console.WriteLine("\t\t강력한 폭발물을 활용해");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                      ※※     //      ※");
                        Console.ResetColor();
                        Console.WriteLine("\t\t길을 뚫거나,");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              //");
                        Console.ResetColor();
                        Console.WriteLine("\t\t적을 제압하는");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              ||");
                        Console.ResetColor();
                        Console.WriteLine("\t\t역할을 맡고 있다.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              ||");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                                              //");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t※ TIP.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("                  @@@@@@@@@@@@@@@@@@@        //");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("              @@@@@@@@@@@@@@@@@@@@@@@@@@@@@//");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t본인에게도");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("            @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t해를 입힐 만큼");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t폭발물은 매우");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("        @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t강력하다.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("      @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,@@@@");
                        Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,@@@@");
                        Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,,@@@");
                        Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,@@@@");
                        Console.WriteLine("   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,,,,,,@@@@@@@");
                        Console.WriteLine("      @@@@@@@@@@@@@@@@@@@@@@@@@@@@,,,,,,,,,@@@@@@@@@");
                        Console.WriteLine("        @@@@@@@@@@@@@@@@@@@@,,,,,,,,,,,,,,@@@@@@@@@");
                        Console.WriteLine("           @@@@@@@,,,,,,,,,,,,,,,,,,,,,,,@@@@@@@@");
                        Console.WriteLine("              @@@@@@@@,,,,,,,,,,,,,,@@@@@@@@@@@");
                        Console.WriteLine("                @@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                        Console.WriteLine("                    @@@@@@@@@@@@@@@@@@@");
                        Console.ResetColor();

                        break;

                    case "소방관":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("                       ㅁㅁㅁ");
                        Console.WriteLine("\t\t\t\t소방관");
                        Console.Write("                       ㅁㅁㅁ");
                        Console.WriteLine("");
                        Console.Write("                    ㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t좀비 상태 발생 당시");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("                 ㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t시민들을 구하려다가");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("             ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t소방서가 무너지고");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("           ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t동료들과 떨어졌다.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("         ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t이후 혼자 살아남아");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("         ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t생존 기술을 익히고,");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("    ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t여전히 사람들을");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("    ㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁㅁ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t노력 중이다.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("            ||                          ||");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("          @@||           @@@@           ||@@");
                        Console.WriteLine("");
                        Console.Write("        @@@@||        @@@@@@@@@@        ||@@@@");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t※ TIP.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("        @@@@||     @@@@@@@oo@@@@@@@     ||@@@@");
                        Console.WriteLine("");
                        Console.Write("     @@@@@@@||   @@@@@@@oooooo@@@@@@@   ||@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t불길 속에서도");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("     @@@@@@@||   @@@@@oooooooooo@@@@@   ||@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t움직일 만큼");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("     @@@@@@@||   @@@@@@@oooooo@@@@@@@   ||@@@@@@@");
                        Console.ResetColor();
                        Console.WriteLine("\t\t기본적인 스탯이 강하며,");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("     (  @@@@||     @@@@@@@oo@@@@@@@     ||@@@@  )");
                        Console.ResetColor();
                        Console.WriteLine("\t\t하이드로펌프를 이용해");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("      ( @@@@||        @@@@@@@@@@        ||@@@@ )");
                        Console.ResetColor();
                        Console.WriteLine("\t\t두 마리의 적을");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("       (  @@||       -(  @@@@  )-       ||@@  )");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t동시에 상대할 수 있다.");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("        (   ||     -)            (-     ||   )");
                        Console.WriteLine("         (  ||   -(                )-   ||  )");
                        Console.WriteLine("          ( || -(                    )- || )");
                        Console.WriteLine("           (||(                       ) ||)");
                        Console.WriteLine("            ||                          ||");
                        Console.WriteLine("            ||                          ||");
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("           |||  00        00        00  |||");  
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("           |||  00        00        00  |||");
                        Console.WriteLine("       ========================================");
                        Console.WriteLine("     ============================================");
                        Console.WriteLine("     ============================================");
                        Console.ResetColor();

                        break;

                    case "이성언 튜터":
                        
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("                        . ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\t\t\t이성언 튜터");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("    .                ...     ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t내일배움캠프에서 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("      .          @@@@@          ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t학생들을 가르치고 있다가");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("       @@@@  @@@@@@@@@@@@@@@....        ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t사회가 붕괴한 후 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("     @@@@@@@@@@@@@@@@@@@@@@@@@  .     ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t혼란 속에서도");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("  ..@@");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("******");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@@@@@@@@@@@@@@@@@@@    .");
                        Console.ResetColor();
                        Console.WriteLine("\t\t지식을 전하려 했다.");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" .");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write ("*");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(",,,,,,,,,,");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("**_______");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@@@@  @@@...");
                        Console.ResetColor();
                        Console.WriteLine("\t\t그러나 생존을 위해");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("  *");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(",,,,,,");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("********");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(",,,,,,,");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@@@@   @@     ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t더 실용적인 기술을 배워야 했고,");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("    *");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(",,,");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" *");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("******");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(",,");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@  @  @     ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t여러 생존자들과 만나면서");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("     **");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''''''''''''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("***" );
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@" );
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" * **        ");
                        Console.ResetColor();
                        Console.WriteLine("\t다양한 기술을 익혔다.");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("    .");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("**");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("^");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''''");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("^");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("'''''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" **");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("   .  ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("ㅇ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''''");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("ㅇ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("**");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t※ TIP.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("     *");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("oo");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("ㅡㅡ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("ooo ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("**");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("      * ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("oo" );
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("''''''''''");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("oooo");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("* ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("@@@ @");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t높은 학습 능력과");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("        ***************");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t\t논리적인 사고를 바탕으로,");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("           *");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("---");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("((((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("****  ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t파괴광선과 볼트태클 스킬을");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("         ***");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("(((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("***");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("((((((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("****  ");
                        Console.ResetColor();
                        Console.WriteLine("\t\t\t익혔다.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("        *");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("(((((((((((((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("--");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("*");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("        *");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("-");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("(((((((((((((");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("--");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("*");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("         ******************     ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("           *");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("######");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#######");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("*");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("            *");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#####");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("#######");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("* ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("             *");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("####");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("######");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("* ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("           ㅇㅇㅇ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ㅇㅇㅇ ");
                        break;

                    case "파피루스":
                        Console.Write("                    .777777777.                             ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("파");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("피");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("루");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("스");
                        Console.ResetColor();
                        Console.WriteLine("                  .7777777777777.                           ");
                        Console.Write("                 .7..777777777777.                          ");
                        Console.WriteLine("좀비 사태 발발 이후, 부산역의 주요 출입구를 지키며 ");
                        Console.Write("                 7777.777777777777                          ");
                        Console.WriteLine("생존자들의 안전을 지키기 위해 검문했다.");
                        Console.Write("                 7777.7777::  ::77.                         ");
                        Console.WriteLine("\"내 검문을 통과하는 자만이 이곳에 들어올 수 있다!\" 라고");
                        Console.Write("                 7777.777777..7777.                         ");
                        Console.WriteLine("외치며 철저하게 검사했다.");
                        Console.Write("                 7777.777777..7777.                         ");
                        Console.WriteLine("생존자들에게 있어서 그는 이 혼란스러운 세상에서");
                        Console.Write("                 77777777777777.:7                          ");
                        Console.WriteLine("한줄기 빛과 같은 존재였다.");
                        Console.Write("                 7.7777..777777.                            ");
                        Console.WriteLine("그는 그의 형, 샌즈가 아직도 살아있다고 믿으며 싸워왔다.");
                        Console.Write("                 .777777777777..                            ");
                        Console.WriteLine("그러나 샌즈가 죽었다는 소식을 접한 후,");
                        Console.Write("                   .7777777777..                            ");
                        Console.WriteLine("혼자의 힘으로 정의를 지키기 위해 싸우기로 결단을 내렸다.");
                        Console.WriteLine("                    .7.?777777...                           ");
                        Console.Write("            .....   .7.777777~.+.   .~~~~.~.                ");
                        Console.WriteLine("정의를 위해서라면 무엇이든 할 준비가 되어 있고,");
                        Console.Write("           ~~~~................7.~~..~,~~~~~~,              ");
                        Console.WriteLine("어떤 위험도 마다하지 않는다.");
                        Console.WriteLine("           ~~~~................7....~~:.+~.~~~~.            ");
                        Console.WriteLine("          .,~~~~.....7.77I7.?77:..~~.IIIIIIII.~~~...~~~~~~. ");
                        Console.WriteLine("      . IIII~~~~~:..7777777777...~~.IIIIIIIIII.~~~~~~~...,~.");
                        Console.WriteLine("    .IIII.II.~~~~~~............~~~IIIIIIIIIIIII~~~~.     .  ");
                        Console.WriteLine("   ?IIIIIIIII.~~~~~~~~~.......~~~I.IIIIIIIIIIII             ");
                        Console.WriteLine("  .IIIII.IIIII.~~~~~~~~~~~~~~~~.IIIIIIIIIIIIIII             ");
                        Console.WriteLine("  :IIIII.IIIIII.~~~~~~~~~~~~~.IIIII.IIIIIIIIII.             ");
                        Console.WriteLine("  .IIIII.IIIIIII?~~.~~~~~~~.IIIIIIII.IIIIIIII.              ");
                        Console.WriteLine("   IIIIIIIIIIIIIII.~I:.,.II~~~IIIIIIII+....+                ");
                        Console.WriteLine("  .+.IIII.IIIIIIIIII.IIIIIIIIIIIIIIIII++++++                ");
                        Console.WriteLine("  .++++...,IIIIIIIIIIIIIII..I.IIIIIII 7777                  ");
                        Console.WriteLine("  .7.++.   .IIIIIIIIIIIIIII.IIIIIIII  7777                  ");
                        Console.WriteLine(" ,777.       .IIIIIIIIIIIIIIIIIIII.   ?777                  ");
                        Console.WriteLine(",777.           ..IIIIIIIIIIII..      :77,                  ");
                        Console.WriteLine("77777777777777? ..  ++++++~           .77.                  ");
                        Console.WriteLine(" .7777777777777.++++++++++.           .77.                  ");
                        Console.WriteLine("               +++++.7777             .77                   ");
                        Console.WriteLine("                .:.+ 7777             777.                  ");
                        Console.WriteLine("       :       .:::: 7777             I77.                  ");
                        Console.WriteLine("       ::.:::::::::..+777             7.7.                  ");
                        Console.WriteLine("       .::::.::::::++++++..           7.7                   ");
                        Console.WriteLine("        .:::::::::.++++++++++~.       7..7                  ");

                        break;
                }

                while (true)
                {
                    
                    Console.WriteLine($"{job}을 선택하셨습니다. 이대로 진행하시겠습니까?");
                    Console.WriteLine("1. 생성하기");
                    Console.WriteLine("0. 다시 선택하기");
                    Console.Write(">> ");

                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("캐릭터 생성을 완료했습니다.");
                        Console.WriteLine($"이름: {name}");
                        Console.WriteLine($"직업: {job}");
                        Thread.Sleep(2000);
                        return new Character(level, name, job, atk, def, maxHp, maxMp, gold, killSans);
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
