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
            {
                if (name == null) {  }

                Console.WriteLine($"이름 : {name}");

                Console.WriteLine("");

                // 직업 입력
                Console.WriteLine("직업을 선택하세요");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 기사");
                Console.WriteLine("3. 마법사");
                Console.WriteLine("4. 궁수");
                Console.WriteLine("5. 도적");
                Console.WriteLine("");
                Console.WriteLine("원하시는 번호를 선택하세요.");
                string selectJob = Console.ReadLine();

                
                // 직업별 스탯 설정
                int level = 1;
                string job = "";
                int atk = 0;
                int def = 0;
                int maxHp = 0;
                int maxMp = 0;
                int gold = 0;   

                
                switch (selectJob)
                {
                        case "1":
                        job = "전사";
                        atk = 0;
                        def = 0;
                        maxHp = 0;
                        maxMp = 0;
                        gold = 0;
                        break;

                        case "2":
                        job = "기사";
                        atk = 0;
                        def = 0;
                        maxHp = 0;
                        maxMp = 0;
                        gold = 0;
                        break;

                        case "3":
                        job = "마법사";
                        atk = 0;
                        def = 0;
                        maxHp = 0;
                        maxMp = 0;
                        gold = 0;
                        break;

                        case "4":
                        job = "궁수";
                        atk = 0;
                        def = 0;
                        maxHp = 0;
                        maxMp = 0;
                        gold = 0;
                        break;

                        case "5":
                        job = "도적";
                        atk = 0;
                        def = 0;
                        maxHp = 0;
                        maxMp = 0;
                        gold = 0;
                        break;

                    default:
                        Console.WriteLine("잘못된 번호입니다. 다시 입력하세요.");
                        return null;
                }

                return new Character(level, name, job, atk, def, maxHp, maxMp, gold);

            }
            
        }
    }
}
