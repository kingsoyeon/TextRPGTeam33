﻿using System;
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
        private static readonly object lockObject = new object();
        private static Dictionary<string, AchievementData> achievements;
        public static Achievement Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Achievement();
                        }
                    }
                }
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


        private Achievement()
        {
            if (achievements == null)
            {
                    achievements = new Dictionary<string, AchievementData>
                {
                    {
                        "FIRST_STEPS",
                        new AchievementData
                        {
                            Name = "첫 발걸음",
                            Description = "게임을 처음 시작했습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    },
                    {
                        "LEVEL_10",
                        new AchievementData
                        {
                            Name = "성장하는 모험가",
                            Description = "레벨 10을 달성했습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    },
                        {
                        "SANS_KILLER",
                        new AchievementData
                        {
                            Name = "샌즈를 처치한 자",
                            Description = "샌즈를 처치했습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    },
                    {
                        "RICH_ADVENTURER",
                        new AchievementData
                        {
                            Name = "부자 모험가",
                            Description = "10000 G를 모았습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    },
                    {
                        "SURVIVOR",
                        new AchievementData
                        {
                            Name = "생존자",
                            Description = "30일 동안 생존했습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    }
                };
            }
        }

        public void CheckAchievements(Character player)
        {
            if (player == null) return;

            // 각 업적 조건을 개별적으로 체크
            if (!achievements["FIRST_STEPS"].IsUnlocked)
            {
                UnlockAchievement("FIRST_STEPS");
            }

            if (player.Level >= 10 && !achievements["LEVEL_10"].IsUnlocked)
            {
                UnlockAchievement("LEVEL_10");
            }

            if (player.KillSans && !achievements["SANS_KILLER"].IsUnlocked)
            {
                UnlockAchievement("SANS_KILLER");
            }

            if (player.Gold >= 10000 && !achievements["RICH_ADVENTURER"].IsUnlocked)
            {
                UnlockAchievement("RICH_ADVENTURER");
            }

            if (Program.days >= 30 && !achievements["SURVIVOR"].IsUnlocked)
            {
                UnlockAchievement("SURVIVOR");
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
            if (loadedAchievements != null)
            {
                achievements = new Dictionary<string, AchievementData>(loadedAchievements);
            }
        }

    }
}
