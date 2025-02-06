using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Character player = new Character("Chad", "전사");

        Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
        Console.Write("이름을 입력해주세요: ");
        string name = Console.ReadLine();
        player.Name = string.IsNullOrEmpty(name) ? "Chad" : name;

        bool inDungeon = true;
        while (inDungeon)
        {
            Console.Clear();
            Console.WriteLine("던전에서 할 수 있는 일을 선택하세요.");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 배틀");
            Console.WriteLine("0. 나가기");
            Console.Write("원하시는 행동을 입력해주세요: ");
            string choice = Console.ReadLine() ?? "0";  // null 처리

            switch (choice)
            {
                case "1":
                    ShowPlayerStats(player);
                    break;
                case "2":
                    ShowInventory(player);
                    break;
                case "3":
                    ShopMenu(player);
                    break;
                case "4":
                    StartBattle(player);
                    break;
                case "0":
                    inDungeon = false;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }
    }

    static void ShowPlayerStats(Character player)
    {
     
    }

    static void ShowInventory(Character player)
    {
      
    }

    static void ShopMenu(Character player)
    {
    
    }

    static void StartBattle(Character player)
    {
        
    }
}



public class Item
{
  
}

class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int AttackPower { get; set; }
    public int DefensePower { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    public List<Item> Inventory { get; set; }

    public Character(string name, string characterClass)
    {
        Name = string.IsNullOrEmpty(name) ? "Chad" : name;
        Class = string.IsNullOrEmpty(characterClass) ? "전사" : characterClass;
        Level = 1;
        AttackPower = 10;
        DefensePower = 5;
        Health = 100;
        Gold = 10000;
        Inventory = new List<Item>();
    }
}

class Shop
{
    public void ShowShopMenu(Character player)
    {
      
    }
}

class Battle
{
    public void StartBattle(Character player, Monster monster)
    {
   
    }
}

class Dungeon
{
    public int Stage { get; set; }
    public List<Monster> Monsters { get; set; }

    public Dungeon()
    {
       
    }

    public void GenerateMonsters()
    {
       
    }

    public void StartDungeon(Character player)
    {
      
    }
}

class Monster
{

}

class Quest
{

}
