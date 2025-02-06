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

        public List<Monster> createMonster()
        {
            List<Monster> createMonster = new List<Monster>();
            Random rand = new Random();
            int monsterCnt = 3;
            int monsterId = 0;

            monsterCnt += rand.Next(0, stageFloor); //몬스터 수 랜덤
            if (monsterCnt > 5) monsterCnt = 5; //몬스터 수 최대 5마리

            if (stageFloor % 5 == 0)
            {
                monsterCnt -= 1;
                createMonster.Add(new Monster("바론", 10, 30, 10));   //보스 몬스터 추가
            }

            for (int i = 0; i < monsterCnt; i++)
            {
                monsterId = rand.Next(0, 3);   //몬스터 종류 랜덤
                createMonster.Add(monsterList[monsterId]);
            }

            return createMonster;
        }
    }
}
