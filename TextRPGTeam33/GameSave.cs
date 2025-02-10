using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRPGTeam33
{
    public class GameSave
    {
        private readonly string saveFile1 = "gamesave1.json";
        private readonly string saveFile2 = "gamesave2.json";
        private readonly string saveFile3 = "gamesave3.json";
        private readonly CharacterCreator characterCreator;

        public class GameData  // 캐릭터와 days를 함께 저장하기 위한 클래스
        {
            public Character Character { get; set; }
            public int CurrentDays { get; set; }
        }

        public GameSave()
        {
            characterCreator = new CharacterCreator();
        }

        public Character DisplaySave()
        {
            if (!HasAnySaveFile())
            {
                return characterCreator.Charactercreator();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("저장된 캐릭터 목록");
                Console.WriteLine("==================");

                // 세이브 1 정보
                DisplaySlotInfo("1. 세이브 1", saveFile1);
                Console.WriteLine();

                // 세이브 2 정보
                DisplaySlotInfo("2. 세이브 2", saveFile2);
                Console.WriteLine();

                // 세이브 3 정보
                DisplaySlotInfo("3. 세이브 3", saveFile3);
                Console.WriteLine();

                Console.WriteLine("0. 돌아가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                string input = Console.ReadLine();

                if (input == "1" || input == "2" || input == "3")
                {
                    string selectedFile = input == "1" ? saveFile1 : (input == "2" ? saveFile2 : saveFile3);

                    // 빈 슬롯 선택시 바로 캐릭터 생성으로
                    if (!File.Exists(selectedFile))
                    {
                        var newPlayer = characterCreator.Charactercreator();
                        if (newPlayer != null)
                        {
                            Save(newPlayer, selectedFile);
                        }
                        return newPlayer;
                    }

                    return HandleSlotSelection(input, selectedFile);
                }
                else if (input == "0")
                {
                    return null;
                }

                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
        }
        private void DisplaySlotInfo(string slotTitle, string filePath)
        {
            Console.WriteLine(slotTitle);
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    var saveData = JsonSerializer.Deserialize<GameData>(jsonString); 
                    Console.WriteLine($"│ Lv.{saveData.Character.Level.ToString("00")} {saveData.Character.Name}[{saveData.Character.Job}]");
                    Console.WriteLine($"│ 생존 {saveData.CurrentDays}일차");
                }
                catch
                {
                    Console.WriteLine("- 빈 슬롯 -");
                }
            }
            else
            {
                Console.WriteLine("- 빈 슬롯 -");
            }
        }
        private Character HandleSlotSelection(string slotNumber, string filePath)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"세이브 {slotNumber} 선택");
                Console.WriteLine("==================");
                Console.WriteLine("1. 시작하기");
                Console.WriteLine("2. 삭제하기");
                Console.WriteLine("0. 돌아가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                string action = Console.ReadLine();

                if (action == "1")
                {
                    if (File.Exists(filePath))
                    {
                        return Load(filePath);
                    }
                    else
                    {
                        var newPlayer = characterCreator.Charactercreator();
                        Save(newPlayer, filePath);
                        return newPlayer;
                    }
                }
                else if (action == "2" && File.Exists(filePath))
                {
                    DeleteSaveFile(filePath);
                    Console.WriteLine("저장 데이터가 삭제되었습니다.");
                    Thread.Sleep(1000);
                    return DisplaySave();  // 삭제 후 저장 목록으로 돌아가기
                }
                else if (action == "0")
                {
                    return DisplaySave();  // 돌아가기 선택시 저장 목록으로
                }

                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(1000);
            }
        }

        public void Save(Character player, string filePath)
        {
            try
            {
                var saveData = new GameData
                {
                    Character = player,
                    CurrentDays = Program.days  // 현재 days도 함께 저장
                };

                string jsonString = JsonSerializer.Serialize(saveData, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filePath, jsonString);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 중 오류가 발생했습니다: {ex.Message}");
                Thread.Sleep(1000);
            }
        }

        private Character Load(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var saveData = JsonSerializer.Deserialize<GameData>(jsonString);
                Program.days = saveData.CurrentDays;  // 저장된 days 복원
                return saveData.Character;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"불러오기 중 오류가 발생했습니다: {ex.Message}");
                Thread.Sleep(1000);
                return null;
            }
        }


        public bool HasAnySaveFile()
        {
            return File.Exists(saveFile1) || File.Exists(saveFile2) || File.Exists(saveFile3);
        }

        private void DeleteSaveFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"저장 파일 삭제 중 오류가 발생했습니다: {ex.Message}");
                    Thread.Sleep(1000);
                }
            }
        }


    }
}
