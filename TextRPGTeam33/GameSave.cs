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
        private readonly string saveDirectory;
        private readonly string saveFile1;
        private readonly string saveFile2;
        private readonly string saveFile3;
        private string currentSaveFile;  // 현재 사용 중인 세이브 파일

        private readonly CharacterCreator characterCreator;
        private static GameSave gameSave;


        public class GameData  // 캐릭터와 days를 함께 저장하기 위한 클래스
        {
            public Character Character { get; set; }
            public int CurrentDays { get; set; }
            public List<Item> InventoryItems { get; set; }
            public int AdventureCount { get; set; }            
        }

        public GameSave()
        {
            // 애플리케이션 데이터 폴더에 저장
            saveDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TextRPGTeam33"
            );

            // 디렉토리가 없으면 생성
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            // 세이브 파일 경로 설정
            saveFile1 = Path.Combine(saveDirectory, "gamesave1.json");
            saveFile2 = Path.Combine(saveDirectory, "gamesave2.json");
            saveFile3 = Path.Combine(saveDirectory, "gamesave3.json");

            characterCreator = new CharacterCreator();
        }

        public Character DisplaySave()
        {
            if (!HasAnySaveFile())
            {
                Character newCharacter = characterCreator.Charactercreator();
                // 새 캐릭터 생성 시 첫 저장 슬롯 설정
                currentSaveFile = saveFile1;
                Save(newCharacter, saveFile1);
                return newCharacter;
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

                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                string input = Console.ReadLine();

                if (input == "1" || input == "2" || input == "3")
                {
                    string selectedFile = input == "1" ? saveFile1 : (input == "2" ? saveFile2 : saveFile3);

                    // 빈 슬롯 선택시 바로 캐릭터 생성으로
                    if (!File.Exists(selectedFile))
                    {
                        currentSaveFile = selectedFile;  // 새 캐릭터 생성 시에도 선택한 슬롯 저장
                        var newPlayer = characterCreator.Charactercreator();
                        if (newPlayer != null)
                        {
                            Save(newPlayer, selectedFile);
                        }
                        return newPlayer;
                    }

                    return HandleSlotSelection(input, selectedFile);
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
                    Console.WriteLine($"│ 생존 {saveData.CurrentDays}일차 탐험횟수:0{saveData.AdventureCount}/02");
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
                    currentSaveFile = filePath; // 여기서 currentSaveFile을 명시적으로 설정

                    if (File.Exists(filePath))
                    {
                        Character loadedCharacter = Load(filePath);
                        return loadedCharacter;
                    }
                    else
                    {
                        var newPlayer = characterCreator.Charactercreator();
                        if (newPlayer != null)
                        {
                            Save(newPlayer, filePath);
                        }
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
                // 디렉토리 생성
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                var saveData = new GameData
                {
                    Character = player,
                    CurrentDays = Program.days,
                    InventoryItems = player.Inventory.GetItems(),
                    AdventureCount = Program.adventureCount
                };

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                string jsonString = JsonSerializer.Serialize(saveData, options);

                File.WriteAllText(filePath, jsonString);

                currentSaveFile = filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 중 오류가 발생했습니다: {ex.Message}");
                Console.WriteLine($"메시지: {ex.Message}");
                Console.WriteLine($"예외 유형: {ex.GetType().Name}");
                Console.WriteLine($"스택 트레이스: {ex.StackTrace}");
                Thread.Sleep(5000);
            }
        }

        private Character Load(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var saveData = JsonSerializer.Deserialize<GameData>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                });

                Program.days = saveData.CurrentDays;
                Program.adventureCount = saveData.AdventureCount;

                Character loadedCharacter = saveData.Character;

                // 인벤토리 복원
                loadedCharacter.Inventory = new Inventory();

                // 아이템 리스트 복원 시 주의
                if (saveData.InventoryItems != null)
                {
                    loadedCharacter.Inventory.AddItem(saveData.InventoryItems);
                }

                currentSaveFile = filePath;
                return loadedCharacter;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"불러오기 중 오류가 발생했습니다: {ex.Message}");
                Console.WriteLine($"예외 상세: {ex.StackTrace}");
                Thread.Sleep(5000);
                return null;
            }
        }


        public bool HasAnySaveFile()
        {
            // 각 저장 파일 경로에 대해 실제 파일 존재 및 유효한 저장 데이터인지 확인
            bool isValidSaveFile(string filePath)
            {
                if (!File.Exists(filePath)) return false;

                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    var saveData = JsonSerializer.Deserialize<GameData>(jsonString);
                    return saveData?.Character != null;
                }
                catch
                {
                    return false;
                }
            }

            return isValidSaveFile(saveFile1) ||
                   isValidSaveFile(saveFile2) ||
                   isValidSaveFile(saveFile3);
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
                    Thread.Sleep(5000);
                }
            }
        }
        public string GetCurrentSaveFile()
        {
            return currentSaveFile;
        }
    }

}
