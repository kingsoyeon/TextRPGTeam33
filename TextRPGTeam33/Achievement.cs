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
            // 추가: 업적 진행도 관련 데이터
            public int Progress { get; set; } = 0;
            public int TargetValue { get; set; } = 0;
        }

        private Dictionary<string, int> combatStats = new Dictionary<string, int>()
        {
            { "TotalKills", 0 },
            { "BossKills", 0 },
        };

        // 전투 통계 업데이트 메서드
        public void UpdateCombatStats(string statName, int value)
        {
            if (combatStats.ContainsKey(statName))
            {
                combatStats[statName] = value;
            }
        }

        public void IncrementCombatStat(string statName)
        {
            if (combatStats.ContainsKey(statName))
            {
                combatStats[statName]++;
            }
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
                            Description = "인류에겐 작은 한 걸음이지만, 당신에겐 위대한 도약입니다.",
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
                        "I_AM_LEGEND",
                        new AchievementData
                        {
                            Name = "나는 전설이다.",
                            Description = "200마리의 적을 처치하세요. 마지막 인류의 희망이 되었습니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue,
                            TargetValue = 200
                        }
                    },
                    {
                        "SURVIVOR",
                        new AchievementData
                        {
                            Name = "28일후",
                            Description = "28일 동안 생존했습니다. 런던은 아직 괜찮을까요?",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue
                        }
                    },
                    {
                        "BOSS_HUNTER",
                        new AchievementData
                        {
                            Name = "T-바이러스 항체",
                            Description = "보스를 5번 처치했습니다. 이제 당신의 피는 특별합니다.",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue,
                            TargetValue = 5
                        }
                    },
                    {
                        "BATTLE_EXPERT",
                        new AchievementData
                        {
                            Name = "어벤져스 어셈블",
                            Description = "100번째 전투 승리. 샤와르마 먹으러 가실래요?",
                            IsUnlocked = false,
                            UnlockDate = DateTime.MinValue,
                            TargetValue = 100
                        }
                    }
                };
            }
        }

        public void CheckAchievements(Character player)
        {
            if (player == null) return;

            // 각 업적 조건을 개별적으로 체크
            if (!achievements["FIRST_STEPS"].IsUnlocked && achievements.ContainsKey("FIRST_STEPS"))
            {
                UnlockAchievement("FIRST_STEPS");
            }

            if (player.Level >= 10 && !achievements["LEVEL_10"].IsUnlocked && achievements.ContainsKey("LEVEL_10"))
            {
                UnlockAchievement("LEVEL_10");
            }

            if (player.KillSans && !achievements["SANS_KILLER"].IsUnlocked && achievements.ContainsKey("SANS_KILLER"))
            {
                UnlockAchievement("SANS_KILLER");
            }

            if (combatStats["TotalKills"] >= 200 && !achievements["I_AM_LEGEND"].IsUnlocked && achievements.ContainsKey("TotalKills"))
            {
                achievements["I_AM_LEGEND"].Progress = combatStats["TotalKills"];
                if (achievements["I_AM_LEGEND"].Progress >= 200 && !achievements["I_AM_LEGEND"].IsUnlocked)
                {
                    UnlockAchievement("I_AM_LEGEND");
                }
            }

            if (Program.days >= 28 && achievements.ContainsKey("SURVIVOR") && !achievements["SURVIVOR"].IsUnlocked)
            {
                UnlockAchievement("SURVIVOR");
            }

            if (combatStats["BossKills"] >= 5 && !achievements["BOSS_HUNTER"].IsUnlocked && achievements.ContainsKey("BOSS_HUNTER"))
            {
                achievements["BOSS_HUNTER"].Progress = combatStats["BossKills"];
                if (achievements["BOSS_HUNTER"].Progress >= 5 && !achievements["BOSS_HUNTER"].IsUnlocked)
                {
                    UnlockAchievement("BOSS_HUNTER");
                }
            }

            if (combatStats["TotalWins"] >= 100 && !achievements["BATTLE_EXPERT"].IsUnlocked && achievements.ContainsKey("BATTLE_EXPERT"))
            {
                achievements["BATTLE_EXPERT"].Progress = player.DungeonClearCount;
                if (achievements["BATTLE_EXPERT"].Progress >= 100 && !achievements["BATTLE_EXPERT"].IsUnlocked)
                {
                    UnlockAchievement("BATTLE_EXPERT");
                }
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

                     // 진행도가 있는 업적의 경우 표시
                    if (achievement.TargetValue > 0)
                    {
                        Console.WriteLine($"  진행도: {achievement.Progress}/{achievement.TargetValue}");
                    }
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
                // 기존 업적은 유지하면서 로드된 상태만 업데이트
                foreach (var kvp in loadedAchievements)
                {
                    if (achievements.ContainsKey(kvp.Key))
                    {
                        achievements[kvp.Key] = kvp.Value;
                    }
                }
            }
        }

    }
}
