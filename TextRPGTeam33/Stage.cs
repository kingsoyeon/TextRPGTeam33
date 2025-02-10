using System.Security.Cryptography.X509Certificates;

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
                new Monster("맹독 좀비", 9, 35, 14, false),
                new Monster("네크로맨서 좀비", 10, 55, 15, false)
            };

            //일반 몬스터 아이템 보상 리스트
            monsterItemList = new List<Item>
            {
                new Item("가죽 자켓", ItemType.Amor, 4, 5, "기본적인 보호를 제공하는 가죽 자켓입니다.", 1000, 1),
                new Item("방탄 조끼", ItemType.Amor, 9, 3, "경찰용 방탄 조끼입니다. 총알을 어느정도 막아줄 것 같습니다.", 2000, 1),
                new Item("야구 방망이", ItemType.Weapon, 5, 5, "임시방편으로 사용하기 좋은 무기입니다.", 600, 1),
                new Item("구급상자", ItemType.Potion, 30, 7, "기본적인 응급처치가 가능한 구급상자입니다.", 500, 1),
                new Item("맛있는 샤와르마", ItemType.Potion, 40, 6, "뉴욕의 작은 가게에서 파는 중동식 샤워르마입니다. 힘든 전투 후에 먹으면 최고!", 1000, 1)
            };
            //보스 몬스터 아이템 보상 리스트
            bossItemList = new List<Item>
            {
                new Item("군용 방탄복", ItemType.Amor, 15, 2, "군대에서 사용하던 고급 방탄복입니다. 매우 튼튼합니다.", 3500, 1),
                new Item("후드 점퍼", ItemType.Amor, 17, 1, "파란색 후드티입니다. 입으면 슬리퍼가 신고 싶어집니다.", 4000, 1),
                new Item("묠니르", ItemType.Weapon, 17, 1, "망치에 새겨진 작은 글씨를 보니 누군가 '누군가 이걸 들 자격이 있다'라고 적어놨습니다.", 3000, 1),
                new Item("버터스카치 파이", ItemType.Potion, 55, 3, "달콤한 향이 나는 수제 파이입니다. 지하세계의 추억이 담겨있습니다.", 2000, 1),
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

            //스테이지 레벨에 따라 몬스터 수 랜덤 증가
            monsterCnt += rand.Next(0, stageLevel);
            if (monsterCnt > 5) monsterCnt = 5; //최대 5마리

            //10층마다 보스 몬스터 추가
            if ((player.DungeonClearCount + 1) % 5 == 0)
            {
                monsterCnt -= 1;
                new Monster("샌즈", 10, 60, 15, true);
            }

            //스테이지 레벨에 따라 몬스터 등장확률 변경
            double monsterSpawnRate = 0;

            if (stageLevel >= 20) monsterSpawnRate = Math.Min(1.0, stageLevel / 30.0);
            else if (stageLevel >= 10) monsterSpawnRate = Math.Min(1.0, stageLevel / 50.0);

            for (int i = 0; i < monsterCnt; i++)
            {
                if (rand.NextDouble() < monsterSpawnRate)
                {
                    minMonsterLv = Math.Min(stageLevel / 3, 6); //강한 몬스터는 6층부터 등장
                    monsterId = rand.Next(minMonsterLv, 10);
                }
                else
                {
                    // 약한 몬스터 등장 (레벨 0~4)
                    monsterId = rand.Next(0, Math.Min(stageLevel / 3 + 1, 5));
                }

                createMonster.Add(new Monster(monsterList[monsterId].name, monsterList[monsterId].level, monsterList[monsterId].hp, monsterList[monsterId].atk, monsterList[monsterId].isBoss));
            }
            return createMonster;
        }

        //전투 종료 후 보상 지급
        public void StageClear(List<Monster> monsterList, int startHp, int skillCnt)
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
            }

            //보상 지급
            player.Gold += rewardGold;
            player.Exp += rewardExp;

            do
            {
                if (player.Exp >= player.LevelUpExp)
                {
                    rewardExp = player.Exp - player.LevelUpExp;
                    player.LevelUpExp *= 2;
                    player.Exp = rewardExp;
                    player.Level++;
                    player.Attack += 1;
                    player.Defense += 1;
                    isLevelUp = true;
                }
                else break;
            }
            while (true);

            //보상 정보 출력
            Console.WriteLine("[캐릭터 정보]");

            if (isLevelUp) Console.WriteLine($"Lv.{curLevel} {player.Name} -> Lv.{player.Level} {player.Name}");
            else Console.WriteLine($"Lv.{player.Level} {player.Name}");

            Console.WriteLine($"HP.{startHp} -> {player.Hp}");

            Console.WriteLine($"exp {curExp} -> {player.Exp}\n");

            Console.WriteLine("[획득 아이템]");

            Console.WriteLine($"{rewardGold} G");

            foreach (Item item in rewardItems)
            {
                Console.WriteLine($"{item.Name} - {item.Count}");
            }

            player.Inventory.AddItem(rewardItems);

            player.DungeonClearCount += 1;
        }
    }
}
