using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class Recipe
    {
        public string Name { get; }  // 결과물 이름
        public List<Item> Materials { get; }  // 재료 아이템들
        public List<int> MaterialCounts { get; }  // 각 재료가 필요한 개수
        public Item Result { get; }  // 결과 아이템
        public string Description { get; }  // 레시피 설명

        public Recipe(string name, List<Item> materials, List<int> materialCounts, Item result, string description)
        {
            Name = name;
            Materials = materials;
            MaterialCounts = materialCounts;
            Result = result;
            Description = description;
        }
    }
    public class CraftingSystem
    {
        private Character player;
        private List<Recipe> recipeList;

        public CraftingSystem(Character player)
        {
            this.player = player;
            this.recipeList = new List<Recipe>
            {
                // 무기 업그레이드 레시피
                new Recipe(
                    "강화된 야구 방망이",
                    new List<Item> {
                        Item.GetItemByName("야구 방망이"),
                        Item.GetItemByName("구급상자")
                    },
                    new List<int> { 1, 1 },  // 각각 1개씩 필요
                    Item.GetItemByName("강화된 야구 방망이"),
                    "야구 방망이를 구급상자로 강화합니다."
                ),
                new Recipe(
                    "바이러스 도끼",
                    new List<Item> {
                        Item.GetItemByName("소방 도끼"),
                        Item.GetItemByName("군용 의료키트")
                    },
                    new List<int> { 1, 1 },
                    Item.GetItemByName("강화된 가죽 조끼"),
                    "가죽 자켓에 방탄 조끼를 결합합니다."
                ),

                //방어구 업그레이 레시피
                new Recipe(
                    "강화된 가죽 조끼",
                    new List<Item> {
                        Item.GetItemByName("가죽 자켓"),
                        Item.GetItemByName("방탄 조끼")
                    },
                    new List<int> { 1, 1 },
                    Item.GetItemByName("강화된 가죽 조끼"),
                    "가죽 자켓에 방탄 조끼를 결합합니다."
                ),
                    new Recipe(
                    "바이러스 갑옷",
                    new List<Item> {
                        Item.GetItemByName("군용 방탄복"),
                        Item.GetItemByName("군용 의료키트")
                    },
                    new List<int> { 1, 1 },
                    Item.GetItemByName("바이러스 갑옷"),
                    "방어구에 좀비의 힘을 주입합니다."
                ),

                // 포션 조합 레시피
                new Recipe(
                    "고급 구급상자",
                    new List<Item> {
                        Item.GetItemByName("구급상자")
                    },
                    new List<int> { 2 },  // 구급상자 2개 필요
                    Item.GetItemByName("고급 구급상자"),
                    "구급상자 2개를 조합하여 더 강력한 치료 효과를 만듭니다."
                ),

                 // MP 포션 조합 레시피
                new Recipe(
                    "특제 파이",
                    new List<Item> {
                        Item.GetItemByName("버터스카치 파이")
                    },
                    new List<int> { 2 },
                     Item.GetItemByName("특제 파이"),
                    "파이 2개를 조합하여 더 강력한 마나 회복 효과를 만듭니다."
                )
            };
        }

        public void DisplayCraftingMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("                     제작대                      ");
                Console.WriteLine("================================================\n");

                Console.WriteLine("-----Player-------------------------------------\n");
                Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Job})\n");
                Console.Write("Gold : ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{player.Gold} G");
                Console.ResetColor();
                Console.WriteLine("\n\n------------------------------------------------\n");

                Console.WriteLine("-----Recipes------------------------------------\n");

                for (int i = 0; i < recipeList.Count; i++)
                {
                    var recipe = recipeList[i];
                    if (recipe.Result.Type == ItemType.Weapon)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("●");
                    }
                    else if (recipe.Result.Type == ItemType.Amor)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("●");
                    }
                    else if (recipe.Result.Type == ItemType.Potion)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("●");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("●");
                    }
                    Console.ResetColor();

                    Console.WriteLine($"\n{i + 1}. {recipe.Name}");
                    Console.WriteLine($"   {recipe.Description}");

                    // 결과물 정보 표시
                    string statInfo = "";
                    if (recipe.Result.Type == ItemType.Weapon)
                        statInfo = $"공격력 +{recipe.Result.Value}";
                    else if (recipe.Result.Type == ItemType.Amor)
                        statInfo = $"방어력 +{recipe.Result.Value}";
                    else if (recipe.Result.Type == ItemType.Potion)
                        statInfo = $"HP회복 +{recipe.Result.Value}";
                    else if (recipe.Result.Type == ItemType.MPPotion)
                        statInfo = $"MP회복 +{recipe.Result.Value}";

                    Console.WriteLine($"   - {statInfo}");
                    Console.WriteLine($"   - 가격: {recipe.Result.Cost} G");

                    // 필요 재료 표시
                    Console.WriteLine("   [필요 재료]");
                    for (int j = 0; j < recipe.Materials.Count; j++)
                    {
                        if (recipe.MaterialCounts[j] > 0)
                        {
                            var material = recipe.Materials[j];
                            int owned = CountPlayerItem(material.Name);
                            Console.Write($"   - {material.Name} x{recipe.MaterialCounts[j]}");
                            if (owned >= recipe.MaterialCounts[j])
                                Console.ForegroundColor = ConsoleColor.Green;
                            else
                                Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($" (보유: {owned})");
                            Console.ResetColor();
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(" 1. 아이템 제작              0. 나가기          ");
                Console.WriteLine("------------------------------------------------\n");

                Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;

                else if (input == "1")
                {
                    SelectRecipe();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }
        private void SelectRecipe()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine("                  제작할 아이템                  ");
                Console.WriteLine("================================================\n");

                for (int i = 0; i < recipeList.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {recipeList[i].Name}");
                }

                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine(" 0. 나가기");
                Console.WriteLine("------------------------------------------------\n");

                Console.Write("제작할 아이템을 선택해주세요.\n>> ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= recipeList.Count)
                {
                    CraftItem(recipeList[choice - 1]);
                    break;
                }
                else if (choice == 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }


        int CountPlayerItem(string itemName)
        {
            var items = player.Inventory.GetItems();
            var item = items.Find(i => i.Name == itemName);
            return item?.Count ?? 0;
        }

        void CraftItem(Recipe recipe)
        {
            //재료 확인
            for (int i = 0; i < recipe.Materials.Count; i++)
            {
                if (recipe.MaterialCounts[i] > 0)
                {
                    int owned = CountPlayerItem(recipe.Materials[i].Name);
                    if (owned < recipe.MaterialCounts[i])
                    {
                        Console.WriteLine($"\n재료가 부족합니다: {recipe.Materials[i].Name}");
                        Thread.Sleep(1500);
                        return;
                    }
                }
            }

            //재료 소비
            var inventory = player.Inventory.GetItems();
            for (int i = 0; i < recipe.Materials.Count; i++)
            {
                if (recipe.MaterialCounts[i] > 0)
                {
                    var material = inventory.Find(item => item.Name == recipe.Materials[i].Name);
                    material.Count -= recipe.MaterialCounts[i];
                    if (material.Count <= 0)
                    {
                        player.Inventory.RemoveItem(material);
                    }
                }
            }

            // 아이템 생성
            var newItem = Item.CreateNewItem(recipe.Result);
            player.Inventory.AddItem(newItem);

            Console.WriteLine($"\n{recipe.Name} 제작 성공!");
            Thread.Sleep(1500);
        }
    }
}

