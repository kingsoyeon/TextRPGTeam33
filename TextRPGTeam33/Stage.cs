﻿using System.Security.Cryptography.X509Certificates;

namespace TextRPGTeam33
{
    public class Stage
    {
        private Character player;
        private List<Monster> monsterList;
        private List<Item> monsterItemList;
        private List<Item> bossItemList;

        public Stage(Character player)
        {
            this.player = player;

            //몬스터 리스트
            monsterList = new List<Monster>
            {
                new Monster("기본 좀비", 1, 10, 5, false),
                new Monster("썩은 좀비", 2, 14, 6, false),
                new Monster("광폭 좀비", 3, 18, 8, false),
                new Monster("기어 다니는 좀비", 4, 22, 7, false),
                new Monster("돌연변이 좀비", 5, 28, 9, false),
                new Monster("스프린터 좀비", 6, 24, 10, false),
                new Monster("덩치 좀비", 7, 40, 12, false),
                new Monster("폭발성 좀비", 8, 32, 13, false),
                new Monster("맹독 좀비", 9, 35, 14, false)
            };

            //일반 몬스터 아이템 보상 리스트
            monsterItemList = new List<Item>
            {
                new Item("가죽 자켓", ItemType.Amor, 4, 5, "기본적인 보호를 제공하는 가죽 자켓입니다.", 1000, 1),
                new Item("방탄 조끼", ItemType.Amor, 9, 3, "경찰용 방탄 조끼입니다. 총알을 어느정도 막아줄 것 같습니다.", 2000, 1),
                new Item("야구 방망이", ItemType.Weapon, 5, 5, "임시방편으로 사용하기 좋은 무기입니다.", 600, 1),
                new Item("구급상자", ItemType.Potion, 30, 7, "기본적인 응급처치가 가능한 구급상자입니다.", 500, 1),
                new Item("버터스카치 파이", ItemType.MPPotion, 30, 7, "달콤한 향이 나는 수제 파이입니다. 지하세계의 추억이 담겨있습니다.", 800, 1)
            };
            //보스 몬스터 아이템 보상 리스트
            bossItemList = new List<Item>
            {
                new Item("군용 방탄복", ItemType.Amor, 15, 2, "군대에서 사용하던 고급 방탄복입니다. 매우 튼튼합니다.", 3500, 1),
                new Item("후드 점퍼", ItemType.Amor, 17, 1, "파란색 후드티입니다. 입으면 슬리퍼가 신고 싶어집니다.", 4000, 1),
                new Item("묠니르", ItemType.Weapon, 17, 1, "망치에 새겨진 작은 글씨를 보니 누군가 '누군가 이걸 들 자격이 있다'라고 적어놨습니다.", 3000, 1),
                new Item("파피루스의 뼈조각", ItemType.Weapon, 0, 80, "???", 0, 1),
                new Item("맛있는 샤와르마", ItemType.Potion, 40, 5, "뉴욕의 작은 가게에서 파는 중동식 샤워르마입니다. 힘든 전투 후에 먹으면 최고!", 1000, 1),
                new Item("특제 스테이크", ItemType.MPPotion, 45, 5, "음식에 고양이 털이 들어갔네요. 하지만 맛은 여전히 최고!", 1200, 1)
            };
        }

        //전투 시작 전 몬스터 랜덤 생성
        public List<Monster> CreateMonster()
        {
            List<Monster> createMonster = new List<Monster>();
            Random rand = new Random();
            int stageLevel = player.DungeonClearCount + 1;  //현재 스테이지 레벨
            int monsterCnt = 3; //기본 몬스터 수
            int monsterId = 0;
            int minMonsterLv = 0;
            int maxMonsterLv = 0;
            int bossLv = 0;
            int bossHp = 0;
            int bossAtk = 0;
            bool isHidden = false;
            int itemCnt = 0;

            //스테이지 레벨에 따라 몬스터 수 증가 확률 조정 - 최대 4마리(30층 이후 100%)
            double increaseRate = Math.Min(1.0, (double)stageLevel / 30.0);
            if (rand.NextDouble() < increaseRate) monsterCnt++;

            //전투 횟수 10회마다 보스 몬스터 추가
            if ((stageLevel) % 10 == 0)
            {
                if (stageLevel >= 30)
                {
                    //파피루스의 뼈조각 수량에 따라 히든 보스 조우 확률 증가
                    List<Item> item = player.Inventory.GetItems();
                    foreach (Item x in item)
                    {
                        if (x.Name == "파피루스의 뼈조각")
                        {
                            itemCnt = x.Count;
                            break;
                        }
                    }
                    double hiddenRate = itemCnt * 0.2;

                    hiddenRate = Math.Min(1.0, hiddenRate);

                    if (rand.NextDouble() < hiddenRate)
                    {
                        monsterCnt = 0;
                        isHidden = true;
                        bossLv = stageLevel / 10 * 5;
                        bossHp = stageLevel / 10 * 21;
                        bossAtk = 7 + (stageLevel / 10 * 4);

                        createMonster.Add(new Monster("샌즈", bossLv, bossHp, bossAtk, true));

                        string sansUI = @"
         .::::::::::.         
       ,-~**********:--       
      .!$*          !$*,      
      #~              ,@      
      #~              ,@      
     $-                ,$     
     @. -!!!.     !!!~  @     
     @. :@@@,     @@@!  @     
     @. :@@@, ..  @@@!  @     
     #, ~@@@, :$  @@@; .#     
      #~     !@@$     ,@      
     @@~:$          *!,@@     
     @. :@@@@@@@@@@@@!  @     
     @.  -@,$::$,@.#:   @     
     -**: -*#$$#=@*~.-**~     
     :#@=::!!!!!!!!::*@@:     
    ,#@@@@@-,,,,,,,@@@@@#,    
    @.#@@@@@@@@@@@@@@@@@.#.   
   @@.$;-:@.  :$   @;-:@.#@,  
  .@, ,**-~$##!-###~-;=, ,#-  
 ,*~.==;;$$@:-:*--@$$!:==.-*~ 
 -#  ::!;:;@, ,~  @;:;!::. $: 
 -#.   :!~ @;.   :@.-;;    =: 
 ,=-   ,;* @$-  .$@.!!,   -*~ 
   #,,.**  @-.....@. ;= ,,$,  
    @@,**  @@@@@@@@. ;=.@@.   
    .@#@*  @@@@@@@@. ;@#@,    
     -#@#==@@@@@@@@==#@@-     
     ;@@@@@@@@@@@@@@@@@@;     
     @@@@@@@@@@@@@@@@@@@@     
     @@@@@@@@@@@@@@@@@@@@     
      #@@@@@@@!-@@@@@@@@      
    @@@~    $:  .@    -@@@.   
    @      #@~  .@@     .@.   
    @######,.    ..$#####@.   
    ~~~~~~~        ~~~~~~~    
";
                        Console.WriteLine(sansUI);
                        Thread.Sleep(2000);

                        var removeItem = bossItemList.Find(n => n.Name == "파피루스의 뼈조각"); //보상 목록에서 파피루스의 뼈조각 제외
                        if (removeItem != null)
                        {
                            bossItemList.Remove(removeItem);
                        }
                    }
                }

                if (!isHidden)
                {
                    bossLv = stageLevel / 10 * 4;
                    bossHp = stageLevel / 10 * 20;
                    bossAtk = 6 + (stageLevel / 10 * 4);
                    createMonster.Add(new Monster("네크로맨서 좀비", bossLv, bossHp, bossAtk, true));
                }
            }

            //스테이지 레벨에 따라 몬스터 등장확률 변경
            double monsterSpawnRate = Math.Min(1.0, (double)stageLevel / 50.0);

            for (int i = 0; i < monsterCnt; i++)
            {
                if (rand.NextDouble() < monsterSpawnRate)
                {
                    minMonsterLv = Math.Max(0, stageLevel / 20);  // 최소 레벨
                    maxMonsterLv = Math.Min(9, stageLevel / 6); // 최대 레벨

                    monsterId = rand.Next(minMonsterLv, maxMonsterLv);
                }
                else
                {
                    // 약한 몬스터 등장 (레벨 1~4)
                    maxMonsterLv = Math.Min(4, stageLevel / 12 + 1);
                    monsterId = rand.Next(0, maxMonsterLv);
                }

                createMonster.Add(new Monster(monsterList[monsterId].name, monsterList[monsterId].level, monsterList[monsterId].hp, monsterList[monsterId].atk, monsterList[monsterId].isBoss));
            }
            return createMonster;
        }

        //전투 종료 후 보상 지급
        public void StageClear(List<Monster> monsterList, int startHp, int startMp, int skillCnt)
        {
            Random rand = new Random();
            int itemIdx;
            int curExp = player.Exp;
            int rewardExp = 0;
            int curLevel = player.Level;
            int rewardGold = 0;
            int rewardRate = 0;
            int skillrewardRate = skillCnt * 10;
            bool isLevelUp = false;
            int barLength = 20;
            int curLength = 0;

            List<Item> itemList;
            List<Item> rewardItems = new List<Item>();

            //경험치 = 몬스터 레벨 * 5
            //골드 = (몬스터 레벨 * 50의 90 ~ 110% + 스킬로 인한 추가 비율)
            //보상 아이템 획득 확률은 (아이템별 확률 + (몬스터의 레벨 / 5) + 스킬로 인한 추가 확률)
            foreach (Monster monster in monsterList)
            {
                rewardExp += (monster.level * 5);
                rewardGold += (int)((monster.level * 50) * (1 + (rand.NextDouble() * 0.2 - 0.1 + (skillrewardRate / 100))) / 10) * 10;

                //보스, 일반 몬스터 보상 구분
                if (monster.isBoss) itemList = bossItemList;
                else itemList = monsterItemList;

                foreach (Item item in itemList)
                {
                    rewardRate = item.ItemRate + (monster.level / 5) + skillrewardRate;
                    if (rand.Next(0, 100) < rewardRate)
                    {
                        //동일한 아이템을 획득한 경우 Count++
                        itemIdx = rewardItems.FindIndex(n => n.Name == item.Name);

                        if (itemIdx < 0)
                        {
                            rewardItems.Add(new Item(item.Name, item.Type, item.Value, item.ItemRate, item.Descrip, item.Cost, 1));
                            rewardItems[rewardItems.Count - 1].IsPurchase = true;
                        }
                        else
                        {
                            rewardItems[itemIdx].Count++;
                        }
                    }
                }

                //히든보스 샌즈 처치 시 히든직업 등장
                if (monster.name == "샌즈")
                    player.KillSans = true;
            }

            //보상 지급
            player.Gold += rewardGold;
            isLevelUp = player.LevelUp(rewardExp);

            //보상 정보 출력
            Console.WriteLine("-----Player-------------------------------------\n");

            if (isLevelUp) Console.WriteLine($"Lv.{curLevel} {player.Name} -> Lv.{player.Level} {player.Name}\n");
            else Console.WriteLine($"Lv.{player.Level} {player.Name}\n");

            curLength = (int)((double)player.Hp / player.MaxHP * barLength);

            Console.Write("HP ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(startHp);
            Console.ResetColor();
            Console.Write(" -> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(player.Hp);

            Console.ResetColor();
            Console.Write("\t|");
            Console.BackgroundColor = player.Hp > player.MaxHP / 2 ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
            Console.Write(new string(' ', curLength));
            Console.ResetColor();
            Console.Write(new string(' ', barLength - curLength));
            Console.WriteLine("|");

            curLength = (int)((double)player.Mp / player.MaxMp * barLength);

            Console.Write("MP ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(startMp);
            Console.ResetColor();
            Console.Write(" -> ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player.Mp);

            Console.ResetColor();
            Console.Write("\t|");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(new string(' ', curLength));
            Console.ResetColor();
            Console.Write(new string(' ', barLength - curLength));
            Console.WriteLine("|");

            curLength = (int)((double)player.Exp / player.LevelUpExp * barLength);

            Console.Write("EXP ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(curExp);
            Console.ResetColor();
            Console.Write(" -> ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(player.Exp);

            Console.ResetColor();
            Console.Write("\t|");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(new string(' ', curLength));
            Console.ResetColor();
            Console.Write(new string(' ', barLength - curLength));
            Console.WriteLine("|\n");

            Console.WriteLine("-----Item---------------------------------------\n");

            Console.WriteLine($"{rewardGold} G");

            foreach (Item item in rewardItems)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }
            
            Console.WriteLine("\n------------------------------------------------\n");

            player.Inventory.AddItem(rewardItems);

            player.DungeonClearCount += 1;
            // 100회 승리 업적 확인
            Achievement.Instance.CheckAchievements(player);
        }
    }
}