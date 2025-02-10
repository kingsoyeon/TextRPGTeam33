using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Character
    {
        // 프로퍼티 생성
        public int Level { get; set; }
        public String Name { get; set; }
        public string Job { get; set; }

        
        public int Attack { get; set;  }
        public int PlusAttack { get; set; }


        public int Defense { get; set; }
        public int PlusDefense { get; set; }

        public int Hp { get; set; }
        public int MaxHP { get; set; }

        public int Mp { get; set; }
        public int MaxMp { get; set; }
        public int Gold { get; set; }

        public int Exp { get; set; }
        
        public int LevelUpExp { get; set; }

        public Inventory Inventory { get; set; }
        public int DungeonClearCount { get; set; }

        public bool isLevelUp { get; set; }

        public int speed {  get; set; }


        
        public Character(int level, string name, string job, int atk, int def, int maxHp, int maxMp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = atk;
            PlusAttack = 0;
            Defense = def;
            PlusDefense = 0;
            Gold = gold;
            Hp = maxHp;
            MaxHP = maxHp;
            Mp = maxMp;
            MaxMp = maxMp;

            DungeonClearCount = 0;

            Exp = 0;
            LevelUpExp = 10;
            
            Inventory = new Inventory();

        }

        public Character()
        {
        }

        // 상태 보기 화면
        public void StatusDisplay()
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");

            // 캐릭터 스탯
            Console.WriteLine($"Lv. {Level.ToString("00")}");       // 레벨 2자리수까지 표현
            Console.WriteLine($"{Name} ( {Job} )");

            // 아이템 착용 여부에 따라 스탯 상승/하락에 따른 스탯 반영
            // 공격력
            string plusStat = PlusAttack == 0 ? $"공격력 : {Attack}" : $"공격력 : {Attack + PlusAttack} (+{PlusAttack})";
            Console.WriteLine(plusStat);
            // 방어력
            plusStat = PlusDefense == 0 ? $"방어력 : {Defense}" : $"방어력 : {Defense + PlusDefense} (+{PlusDefense})";
            Console.WriteLine(plusStat);

            Console.WriteLine($"체력 : {Hp} / {MaxHP}");
            Console.WriteLine($"마나 : {Mp} / {MaxMp}");

            Console.WriteLine($"Gold : {Gold}");

            Console.WriteLine("1. 인벤토리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            string input = Console.ReadLine();

            //인벤토리
            if (input == "1")
            {
                // 인벤토리 보이기
               
                Inventory.InventoryScreen(this);
                
            }
            else if (input == "0") 
            {
                return;

            }
            else {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                Console.ReadKey();
                    }

        }

        public void EquipItem(Item item)
        {
            if (item.IsEquip) // 아이템을 장착하고 있으면 해제
            {
                UnEquipItem(item);
            }
            else // 
            {
                item.IsEquip = true; 

                if (item.Type == ItemType.Weapon)    // 아이템 타입이 무기일 경우
                { PlusAttack += item.Value; }
                else      // 갑옷일 경우
                { PlusDefense += item.Value; }
                
            }
        }

        public void UnEquipItem(Item item)
        {
            item.IsEquip = false;

            if (item.Type == ItemType.Weapon) { PlusAttack -= item.Value; }     // 무기일 경우 공격력 감소
            else if ( item.Type == ItemType.Amor)   { PlusDefense -= item.Value; }  // 갑옷일 경우 방어력 감소
        }

        public void LevelUp(int rewardExp)
        {
            
            this.Exp += rewardExp;
            

            do
            {
                if (this.Exp >= this.LevelUpExp)
                {
                    rewardExp = this.Exp - this.LevelUpExp;
                    this.LevelUpExp *= 2;
                    this.Exp = rewardExp;
                    this.Level++;
                    this.Attack += 1;
                    this.Defense += 1;
                    isLevelUp = true;
                }
                else break;
            }
            while (true);
        }

        
    }
}
