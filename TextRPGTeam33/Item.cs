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
        Potion,
        MPPotion
    }
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // 아이템 고유 ID
        public string Name { get; set; } // 아이템 이름
        public ItemType Type { get; set; } // 아이템 타입
        public int Value { get; set; } // 값
        public string Descrip {  get; set; } // 설명
        public int Cost {  get; set; } // 가격
        public int ItemRate { get; set; } // 아이템 확율
        public int Count { get; set; } // 아이템 개수
        public bool IsPurchase { get; set; } //보유 상태
        public bool IsEquip { get; set; } // 장착 여부

        public Item(string name, ItemType type, int value, int itemRate, string descrip, int cost, int count) // 아이템 리스트 초기화
        {
            Id = Guid.NewGuid(); // 새로운 고유 ID 생성
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

        public static Item CreateNewItem(Item original) // 아이템에게 고유 ID 발급
        {
            return new Item(
                original.Name,
                original.Type,
                original.Value,
                original.ItemRate,
                original.Descrip,
                original.Cost,
                original.Count
            );
        }

        public static Item GetItemByName(string name)
        {
            var allItems = itemList();
            var item = allItems.Find(i => i.Name == name);

            if (item == null)
            {
                // 특별 아이템을 여기서 직접 생성
                switch (name)
                {
                    case "강화된 야구 방망이":
                        return new Item(name, ItemType.Weapon, 20, 100, "야구 방망이에 추가적인 강화가 적용되었습니다.", 1200, 1);
                    case "바이러스 도끼":
                        return new Item(name, ItemType.Weapon, 30, 100, "좀비의 독이 스며든 강력한 도끼입니다.", 2800, 1);
                    case "강화된 가죽 조끼":
                        return new Item(name, ItemType.Amor, 14, 100, "가죽 자켓에 방탄 기능이 추가되었습니다.", 3200, 1);
                    case "바이러스 갑옷":
                        return new Item(name, ItemType.Amor, 22, 100, "좀비의 힘이 깃든 갑옷. 보호력과 저항력이 강화됩니다.", 5000, 1);
                    case "고급 구급상자":
                        return new Item(name, ItemType.Potion, 70, 100, "더 강력한 치료 효과를 제공하는 구급상자입니다.", 1500, 1);
                    case "특제 파이":
                        return new Item(name, ItemType.MPPotion, 60, 100, "마법적인 효과가 강화된 파이입니다.", 3000, 1);
                }

                Console.WriteLine($"[오류] 아이템 '{name}'을 찾을 수 없습니다.");
            }

            return item;
        }


        public static List<Item> itemList() //아이템 리스트
        {
            return new List<Item> // 이름, 타입, 값(공격력, 방어력, 회복력), 확률, 설명, 가격, 수(포션전용)
            {
                //방어구
                new Item("가죽 자켓", ItemType.Amor, 4, 100, "기본적인 보호를 제공하는 가죽 자켓입니다.", 1000, 1),
                new Item("방탄 조끼", ItemType.Amor, 9, 100, "경찰용 방탄 조끼입니다. 총알을 어느정도 막아줄 것 같습니다.", 2000, 1),
                new Item("군용 방탄복", ItemType.Amor, 15, 100, "군대에서 사용하던 고급 방탄복입니다. 매우 튼튼합니다.", 3500, 1),
                new Item("후드 점퍼", ItemType.Amor, 17, 100, "파란색 후드티입니다. 입으면 슬리퍼가 신고 싶어집니다.", 4000, 1),
                // 무기
                new Item("야구 방망이", ItemType.Weapon, 5, 100, "임시방편으로 사용하기 좋은 무기입니다.", 600, 1),
                new Item("소방 도끼", ItemType.Weapon, 10, 100, "소방서에서 가져온 도끼입니다. 좀비와 문 모두에게 효과적입니다.", 1500, 1),
                new Item("묠니르", ItemType.Weapon, 17, 100, "망치에 새겨진 작은 글씨를 보니 누군가 '누군가 이걸 들 자격이 있다'라고 적어놨습니다.", 3000, 1),
                // HP회복
                new Item("구급상자", ItemType.Potion, 30, 100, "기본적인 응급처치가 가능한 구급상자입니다.", 500, 1),
                new Item("맛있는 샤와르마", ItemType.Potion, 40, 100, "뉴욕의 작은 가게에서 파는 중동식 샤워르마입니다. 힘든 전투 후에 먹으면 최고!", 1000, 1),
                new Item("군용 의료키트", ItemType.Potion, 50, 100, "군용 의료키트입니다. 중상 치료도 가능합니다.", 1000, 1),
                // MP회복
                new Item("버터스카치 파이", ItemType.MPPotion, 30, 100, "달콤한 향이 나는 수제 파이입니다. 지하세계의 추억이 담겨있습니다.", 800, 1),
                new Item("특제 스테이크", ItemType.MPPotion, 25, 100, "음식에 고양이 털이 들어갔네요. 하지만 맛은 여전히 최고!", 1200, 1),
            };
        }

    }

}
