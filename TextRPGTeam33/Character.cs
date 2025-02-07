using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Character
    {
        // 프로퍼티 생성
        public int Level { get; }
        public String Name { get; set; }
        public string Job { get; }

        
        public int Attack { get; }
        public int PlusAttack { get; set; }


        public int Defense { get; }
        public int PlusDefense { get; set; }

        public int Hp { get; set; }
        public int MaxHP { get; }
        public int Gold { get; set; }

        public Inventory Inventory { get; }
        public int DungeonClearCount { get; set; }


        
        public Character(int level, string name, string job, int atk, int def, int maxHp, int gold)
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
            DungeonClearCount = 0;

            Inventory = new Inventory();

        }

        // 상태 보기 화면
        public void StatusDisplay() 
        {
            Console.WriteLine($"Lv. {Level.ToString("00")}");       // 레벨 2자리수까지 표현
            Console.WriteLine($"{Name} ( {Job} )");
            
            // 아이템 착용 여부에 따라 스탯 상승/하락에 따른 스탯 반영
            // 공격력
            string plusStat = PlusAttack == 0 ? $"공격력 : {Attack}" : $"공격력 : {Attack + PlusAttack} (+{PlusAttack})";
            Console.WriteLine(plusStat);
            // 방어력
            plusStat = PlusDefense == 0 ? $"방어력 : {Defense}" : $"방어력 : {Defense + PlusDefense} (+{Defense})";
            Console.WriteLine(plusStat);

            Console.WriteLine($"체력 : {Hp} / {MaxHP}");
            Console.WriteLine($"Gold : {Gold}");
        }

        public void EquipItem(Item item)
        {
            if (item.IsEquip)
            {
                UnEquipItem(item);
            }
            else
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

        // 포션 사용
        public void UsePotion(Item item)
        {
            Hp += item.Value;

            Console.WriteLine($"{item.Name}을(를) 사용했습니다.");
            if (Hp > MaxHP)     // Hp가 MaxHP를 초과하지 않도록 제한
            {
                Hp = MaxHP;
            }

            Inventory.RemoveItem(item);

            Console.WriteLine($"현재 체력: {Hp}/{MaxHP}");

        }
    }
}
