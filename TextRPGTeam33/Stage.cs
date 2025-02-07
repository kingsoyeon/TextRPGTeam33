namespace TextRPGTeam33
{
    public class Stage
    {
        List<Monster> monsterList;

        public int stageFloor { get; set; } = 5;

        public Stage()
        {
            monsterList = new List<Monster>
            {
                new Monster("미니언", 2, 15, 5),
                new Monster("공허충", 3, 10, 9),
                new Monster("대포미니언", 5, 25, 8)
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
                createMonster.Add(monsterList[monsterId]);
            }

            return createMonster;
        }

        //전투 종료 후 보상 지급
        public List<object> StageClear(List<Monster> monsterList)
        {
            List<object> reward = new List<object>();

            Random rand = new Random();
            int exp = 0;
            int gold = 0;
            List<Item> items = new List<Item>();

            //경험치는 몬스터 레벨 * 5만큼 획득
            //골드는 몬스터 레벨 * 50의 90 ~ 110% 만큼 획득
            foreach (Monster monster in monsterList)
            {
                exp += (monster.level * 5);
                gold += (int)  ( (monster.level * 50) * ( 1 + (rand.NextDouble() * 0.2 - 0.1 ) ) );
            }

            reward.Add(exp);
            reward.Add(gold);
            reward.Add(items);

            return reward;
        }
    }
}
