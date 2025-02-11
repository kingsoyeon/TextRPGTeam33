using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TextRPGTeam33.Achievement;

namespace TextRPGTeam33
{
    public class Achievement
    {
        private static Achievement instance;
        public static Achievement Instance
        {
            get
            {
                if (instance == null)
                    instance = new Achievement();
                return instance;
            }
        }

        public class AchievementData
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsUnlocked { get; set; }
            public DateTime UnlockDate { get; set; }
        }

        private Dictionary<string, AchievementData> achievements;

        private Achievement()
        {
            achievements = new Dictionary<string, AchievementData>
            {
                {
                    "FIRST_STEPS",
                    new AchievementData
                    {
                        Name = "첫 발걸음",
                        Description = "게임을 처음 시작했습니다.",
                        IsUnlocked = false
                    }
                },
                {
                    "LEVEL_10",
                    new AchievementData
                    {
                        Name = "성장하는 모험가",
                        Description = "레벨 10을 달성했습니다.",
                        IsUnlocked = false
                    }
                },
                 {
                    "SANS_KILLER",
                    new AchievementData
                    {
                        Name = "센즈를 처치한 자",
                        Description = "Sans를 처치했습니다.",
                        IsUnlocked = false
                    }
                },
                {
                    "RICH_ADVENTURER",
                    new AchievementData
                    {
                        Name = "부자 모험가",
                        Description = "10000 G를 모았습니다.",
                        IsUnlocked = false
                    }
                },
                {
                    "SURVIVOR",
                    new AchievementData
                    {
                        Name = "생존자",
                        Description = "30일 동안 생존했습니다.",
                        IsUnlocked = false
                    }
                }
            };
        }

        public void CheckAchievements(Character player)
        {
            UnlockAchievement("FIRST_STEPS"); // 첫 발걸음

            if (player.Level >= 10) // 10레벨 이상일시 
            {
                UnlockAchievement("LEVEL_10");  //성장하는 모험가
            }

            if (player.KillSans)
            {
                UnlockAchievement("SANS_KILLER"); // 센즈를 처치한 자
            }
            if (player.Gold >= 10000)
            {
                UnlockAchievement("RICH_ADVENTURER"); // 부자 모험가
            }
            if (Program.days >= 30)
            {
                UnlockAchievement("SURVIVOR"); // 생존자
            }
        }

        private void UnlockAchievement(string achievementId)
        {
            if (achievements.ContainsKey(achievementId) && !achievements[achievementId].IsUnlocked)
            {
                achievements[achievementId].IsUnlocked = true;
                achievements[achievementId].UnlockDate = DateTime.Now;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n★ 업적 달성! ★");
                Console.WriteLine($"[{achievements[achievementId].Name}]");
                Console.WriteLine(achievements[achievementId].Description);
                Console.ResetColor();
                Thread.Sleep(2000);
            }
        }

        public void DisplayAchievements()
        {
            Console.Clear();
            Console.WriteLine("== 업적 목록 ==");
            Console.WriteLine("===============");
            
            foreach (var achievement in achievements.Values)
            {
                if (achievement.IsUnlocked)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ {achievement.Name}");
                    Console.WriteLine($"  {achievement.Description}");
                    Console.WriteLine($"  달성일: {achievement.UnlockDate:yyyy-MM-dd HH:mm:ss}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"□ {achievement.Name}");
                    Console.WriteLine($"  {achievement.Description}");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine("\n아무 키나 누르면 돌아갑니다...");
            Console.ReadKey(true);
        }

        public Dictionary<string, AchievementData> GetAchievements()
        {
            return achievements;
        }

        public void LoadAchievements(Dictionary<string, AchievementData> loadedAchievements)
        {
            if (loadedAchievements == null)
            {
                achievements = loadedAchievements;
            }
        }
        
    }
}
