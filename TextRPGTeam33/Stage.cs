namespace TextRPGTeam33
{
    public class Stage
    {
        private Character player;
        private Inventory inventory;
        List<Monster> monsterList;
        List<Item> itemList;

        public int stageFloor { get; set; } = 1;

        public Stage(Character player, Inventory inventory)
        {
            this.player = player;
            this.inventory = inventory;

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

            monsterCnt += rand.Next(0, stageFloor); //몬스터 수 랜덤
            if (monsterCnt > 5) monsterCnt = 5; //몬스터 수 최대 5마리

            //5층마다 보스 몬스터 추가
            if (stageFloor % 5 == 0)
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
        public void StageClear(List<Monster> monsterList)
        {
            Random rand = new Random();
            int exp = 0;
            int gold = 0;
            int rewardRate = 0;
            List<Item> rewardItems = new List<Item>();

            //경험치는 몬스터 레벨 * 5만큼 획득
            //골드는 몬스터 레벨 * 50의 90 ~ 110% 만큼 획득
            //보상 아이템 획득 확률은 (아이템별 확률 + (몬스터의 레벨 / 5))
            foreach (Monster monster in monsterList)
            {
                exp += (monster.level * 5);
                gold += (int)((monster.level * 50) * (1 + (rand.NextDouble() * 0.2 - 0.1)));

                foreach (Item item in itemList)
                {
                    rewardRate = item.ItemRate + monster.level / 5;
                    if (rand.Next(0, 100) < rewardRate)
                    {
                        rewardItems.Add(item);
                        rewardItems.Add(new Item(item.Name, item.Type, item.Value, item.ItemRate, item.Descrip, item.Cost, 1));
                    }
                }
            }

            //보상 지급
            player.Gold += gold;
            inventory.AddItem(rewardItems);
            stageFloor += 1;
        }
    }
}
