using System.Security.Cryptography.X509Certificates;

namespace TextRPGTeam33
{
    public class Stage
    {
        private Character player;
        private List<Monster> monsterList;
        private List<Item> itemList;

        public Stage(Character player)
        {
            this.player = player;

            //몬스터 리스트
            monsterList = new List<Monster>
            {
                new Monster("미니언", 2, 15, 5),
                new Monster("공허충", 3, 10, 9),
                new Monster("대포미니언", 5, 25, 8)
            };

            //스테이지 클리어 아이템 보상리스트
            itemList = new List<Item>
            {
                new Item("수련자의 갑옷", ItemType.Amor, 4, 3, "수련에 도움을 주는 갑옷입니다.", 1000, 1),
                new Item("낡은 검", ItemType.Weapon, 5, 3, "쉽게 볼 수 있는 낡은 검 입니다.", 600, 1),
                new Item("회복 포션", ItemType.Potion, 30, 10, "스파르타의 전사들이 사용했다는 전설의 포션입니다.", 1000, 1)
            };
        }

        //전투 시작 전 몬스터 랜덤 생성
        public List<Monster> CreateMonster()
        {
            List<Monster> createMonster = new List<Monster>();
            Random rand = new Random();
            int monsterCnt = 3;
            int monsterId = 0;

            monsterCnt += rand.Next(0, player.DungeonClearCount + 1); //몬스터 수 랜덤
            if (monsterCnt > 5) monsterCnt = 5; //몬스터 수 최대 5마리

            //5층마다 보스 몬스터 추가
            if ((player.DungeonClearCount + 1) % 5 == 0)
            {
                monsterCnt -= 1;
                createMonster.Add(new Monster("바론", 10, 30, 10));
            }

            for (int i = 0; i < monsterCnt; i++)
            {
                monsterId = rand.Next(0, 3);   //몬스터 종류 랜덤
                createMonster.Add(new Monster(monsterList[monsterId].name, monsterList[monsterId].level, monsterList[monsterId].hp, monsterList[monsterId].atk));
            }

            return createMonster;
        }

        //전투 종료 후 보상 지급
        public void StageClear(List<Monster> monsterList, int startHp)
        {

            Random rand = new Random();
            int itemIdx;
            int curExp = player.Exp;
            int rewardExp = 0;
            int curLevel = player.Level;
            int rewardGold = 0;
            int rewardRate = 0;
            bool isLevelUp = false;
            List<Item> rewardItems = new List<Item>();

            //경험치는 몬스터 레벨 * 5만큼 획득
            //골드는 몬스터 레벨 * 50의 90 ~ 110% 만큼 획득
            //보상 아이템 획득 확률은 (아이템별 확률 + (몬스터의 레벨 / 5))
            foreach (Monster monster in monsterList)
            {
                rewardExp += (monster.level * 5);
                rewardGold += (int)((monster.level * 50) * (1 + (rand.NextDouble() * 0.2 - 0.1)) / 10) * 10;

                foreach (Item item in itemList)
                {
                    rewardRate = item.ItemRate + monster.level / 5;
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
                    //player.Level++;
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
