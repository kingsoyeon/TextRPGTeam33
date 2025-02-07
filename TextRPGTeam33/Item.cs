using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public enum ItemType // 아이템 타입
    {
        Weapon,
        Amor,
        Potion
    }
    public class Item
    {
        public string Name { get; } // 아이템 이름
        public ItemType Type { get; } // 아이템 타입
        public int Value { get; } // 값
        public string Descrip {  get; } // 설명
        public int Cost {  get; } // 가격
        public int ItemRate { get; set; } // 아이템 확율
        public int Count { get; set; } // 아이템 개수
        public bool IsPurchase { get; set; } //보유 상태
        public bool IsEquip { get; set; } // 장착 여부

        public Item(string name, ItemType type, int value, int itemRate, string descrip, int cost, int count) // 아이템 리스트 초기화
        {
            Name = name;
            Type = type;
            Value = value;
            ItemRate = itemRate;
            Descrip = descrip;
            Cost = cost;
            Count = count;
            IsPurchase = false;
            IsEquip = false;
        }

        public static List<Item> itemList() //아이템 리스트
        {
            return new List<Item> // 이름, 타입, 값(공격력, 방어력, 회복력), 확률, 설명, 가격, 수(포션전용)
            {
                new Item("수련자의 갑옷", ItemType.Amor, 4, 100,"수련에 도움을 주는 갑옷입니다.", 1000, 1),
                new Item("무쇠갑옷", ItemType.Amor, 9, 100, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, 1),
                new Item("스파르타의 갑옷", ItemType.Amor, 15, 100, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 1),
                new Item("낡은 검", ItemType.Weapon, 5, 100, "쉽게 볼 수 있는 낡은 검 입니다.", 600, 1),
                new Item("청동 도끼", ItemType.Weapon, 10, 100, "어디선가 사용됐던거 같은 도끼입니다.", 1500, 1),
                new Item("스파르타의 창", ItemType.Weapon, 20, 100, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500, 1),
                new Item("회복 포션", ItemType.Potion, 30, 100, "스파르타의 전사들이 사용했다는 전설의 포션입니다.", 500, 1),
                new Item("고급 회복 포션", ItemType.Potion, 50, 100, "스파르타의 전사들도 사용 못해봤다는 전설의 포션입니다.", 1000, 1)
            };
        }

    }

}
