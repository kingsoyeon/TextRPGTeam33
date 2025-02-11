using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.IO;

namespace TextRPGTeam33
{
    public class GameSave
    {
        private readonly string saveDirectory;
        private readonly string saveFile1;
        private readonly string saveFile2;
        private readonly string saveFile3;
        private readonly string globalDataFile;  // 글로벌 데이터 파일
        private string currentSaveFile;  // 현재 사용 중인 세이브 파일

        private readonly CharacterCreator characterCreator;

        public class GameData  // 캐릭터와 days를 함께 저장하기 위한 클래스
        {
            public Character Character { get; set; }
            public int CurrentDays { get; set; }
            public List<Item> InventoryItems { get; set; }
            public int AdventureCount { get; set; }

            public List<Quest.QuestData> QuestList { get; set; }
            public Dictionary<string, Achievement.AchievementData> Achievements { get; set; }
        }

        public class GlobalData
        {
            public bool HasKilledSans { get; set; }
            public Dictionary<string, Achievement.AchievementData> GlobalAchievements { get; set; }
                = new Dictionary<string, Achievement.AchievementData>();
        }

        private GlobalData globalData;

        public GameSave()
        {
            // 애플리케이션 데이터 폴더에 저장
            saveDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TextRPGTeam33");

            // 디렉토리가 없으면 생성
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }

            // 세이브 파일 경로 설정
            saveFile1 = Path.Combine(saveDirectory, "gamesave1.json");
            saveFile2 = Path.Combine(saveDirectory, "gamesave2.json");
            saveFile3 = Path.Combine(saveDirectory, "gamesave3.json");
            globalDataFile = Path.Combine(saveDirectory, "global.json");

            characterCreator = new CharacterCreator();
            LoadGlobalData();
        }

        public Character DisplaySave()
        {
            if (!HasAnySaveFile()) // 슬롯이 비어있다면...
            {
                var defaultCharacter = new Character();
                defaultCharacter.KillSans = false;
                Character newCharacter = characterCreator.Charactercreator(defaultCharacter); //캐릭터 생성

                currentSaveFile = saveFile1; // 현재 세이브 = 1번 슬롯
                Save(newCharacter, saveFile1); // 1번 슬롯에 세이브
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
                    string selectedFile = input == "1" ? saveFile1 : (input == "2" ? saveFile2 : saveFile3); // 1번이 이라면 saveFile1, 1번이 아닌 2번이라면 saveFile2, 2번도 아니라면 saveFile3
                    currentSaveFile = selectedFile;  // 새 캐릭터 생성 시에도 선택한 슬롯 저장

                    if (!File.Exists(selectedFile)) // 빈 슬롯 선택시 바로 캐릭터 생성으로
                    {
                        bool anySansKilled = CheckAnySansKilled(); // 다른 세이브 데이터에서 Sans 처치 여부 확인
                        var baseCharacter = new Character();
                        baseCharacter.KillSans = anySansKilled;

                        var newPlayer = characterCreator.Charactercreator(baseCharacter); // 캐릭터 생성
                        if (newPlayer != null) // 캐릭터 생성 되었다면...
                        {
                            Save(newPlayer, selectedFile); // 선택된 슬롯에 저장
                        }
                        return newPlayer;
                    }

                    return HandleSlotSelection(input, selectedFile); //캐릭터 선택 함수
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        private void DisplaySlotInfo(string slotTitle, string filePath) //슬롯 정보 출력 함수
        {
            Console.WriteLine(slotTitle); // 슬롯 이름 출력
            if (File.Exists(filePath)) // 슬롯에 데이터가 있다면...
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath); //세이브 데이터(json)의 텍스트를 읽어 문자열로 변환 => 세이브 내용을 jsonString에 저장
                    var saveData = JsonSerializer.Deserialize<GameData>(jsonString); //json 문자열 타입<GameData)를 객체로 변환 => saveData에 변수로 저장
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
        private Character HandleSlotSelection(string slotNumber, string filePath) //캐릭터 선택 함수
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

                if (action == "1") // 1. 시작하기 선택
                {
                    currentSaveFile = filePath; // 선택된 슬롯을 저장 슬롯으로 지정

                    if (File.Exists(filePath)) // 세이브 데이터가 있다면
                    {
                        Character loadedCharacter = Load(filePath); // 캐릭터 데이터 불러온다. => Load()
                        return loadedCharacter;
                    }
                    else // 슬롯이 비어있다면...
                    {
                        bool anySansKilled = CheckAnySansKilled(); // 다른 세이브 파일들에서 Sans 처치 여부 확인
                        var baseCharacter = new Character();
                        baseCharacter.KillSans = anySansKilled;
                        var newPlayer = characterCreator.Charactercreator(baseCharacter); // 캐릭터 생성
                        if (newPlayer != null)
                        {
                            Save(newPlayer, filePath);
                        }
                        return newPlayer;
                    }
                }
                else if (action == "2" && File.Exists(filePath)) // 세이브 파일이 있고, 2. 삭제하기 선택
                {
                    DeleteSaveFile(filePath); // 세이브 데이터 삭제
                    Console.WriteLine("저장 데이터가 삭제되었습니다.");
                    Thread.Sleep(1000);
                    return DisplaySave();  // 삭제 후 저장 목록으로 돌아가기
                }
                else if (action == "0") // 0. 돌아가기 선택
                {
                    return DisplaySave();  // 돌아가기 선택시 저장 목록으로
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000);
                }
            }
        }

        public void Save(Character player, string filePath) // 데이터 저장 함수
        {
            try
            {
                if (player.KillSans)
                {
                    globalData.HasKilledSans = true;
                    SaveGlobalData();
                }
                var saveData = new GameData // saveData에 GameData(json)
                {
                    Character = player, // 캐릭터 정보
                    CurrentDays = Program.days, // 날짜 정보
                    InventoryItems = player.Inventory.GetItems(), // 인벤토리 정보
                    AdventureCount = Program.adventureCount, // 탐험 횟수 
                    QuestList = Quest.Instance.GetQuestList(),  // 퀘스트 리스트 저장
                    Achievements = Achievement.Instance.GetAchievements() // 업적 저장
                };

                UpdateGlobalAchievements(saveData.Achievements);

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, //true = Json 들여쓰기와 줄바꿈 형식으로 저장 
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles, // 무한 참조 루프 방지, IgnoreCycles: 순환 참조 무시
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull // Null값을 가진 속성을 Json으로 직렬화할때 처리 // WhenWritingNull: Null 값은 저장 안됨
                };

                string jsonString = JsonSerializer.Serialize(saveData, options); //Json 문자열 변환 (Gamedata, option)
                File.WriteAllText(filePath, jsonString); // Json 문자열 파일을 저장
                currentSaveFile = filePath; // 선택된 슬롯을 저장 슬롯으로 지정
            }
            catch (Exception ex) // Save() 오류 텍스트 출력
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
                string jsonString = File.ReadAllText(filePath); //세이브 데이터(json)의 텍스트를 읽어 문자열로 변환 => 세이브 내용을 jsonString에 저장

                var saveData = JsonSerializer.Deserialize<GameData>(jsonString, new JsonSerializerOptions //json 문자열 타입<GameData)를 객체로 변환 => saveData에 변수로 저장
                {
                    PropertyNameCaseInsensitive = true, // 속성 이름 비교할 때 대소문자 구분 X
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles // 무한 참조 루프 방지, IgnoreCycles: 순환 참조 무시
                });

                Program.days = saveData.CurrentDays; //  saveData의 CurrentDays를 Program의 days에 저장
                Program.adventureCount = saveData.AdventureCount; //  saveData의 AdventureCount를 Program의 adventureCount에 저장

                Character loadedCharacter = saveData.Character; // saveData의 캐릭터 정보를 Charater에 저장
                loadedCharacter.Inventory = new Inventory(); // 새로운 Inventory 인스턴스 생성하여 할당

                if (saveData.InventoryItems != null) // saveData에 인벤토리 아이템이 비어있지 않다면...
                {
                    loadedCharacter.Inventory.AddItem(saveData.InventoryItems); // saveData의 아이템들을 Character의 인벤토리에 저장
                }
                if (saveData.QuestList != null)
                {
                    Quest.Instance.LoadQuestList(saveData.QuestList);  // 퀘스트 리스트 로드
                }
                if (saveData.Achievements != null)
                {
                    foreach (var achievement in globalData.GlobalAchievements)
                    {
                        if (achievement.Value.IsUnlocked)
                        {
                            saveData.Achievements[achievement.Key].IsUnlocked = true;
                            saveData.Achievements[achievement.Key].UnlockDate = achievement.Value.UnlockDate;
                        }
                    }
                    Achievement.Instance.LoadAchievements(saveData.Achievements);
                }

                return loadedCharacter;
            }
            catch (Exception ex) // Load() 오류 텍스트 출력
            {
                Console.WriteLine($"불러오기 중 오류가 발생했습니다: {ex.Message}");
                Console.WriteLine($"예외 상세: {ex.StackTrace}");
                Thread.Sleep(5000);
                return null;
            }
        }

        private void SaveGlobalData()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
                };

                string jsonString = JsonSerializer.Serialize(globalData, options);
                File.WriteAllText(globalDataFile, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"글로벌 데이터 저장 중 오류 발생: {ex.Message}");
            }
        }

        private void LoadGlobalData()
        {
            try
            {
                if (File.Exists(globalDataFile))
                {
                    string jsonString = File.ReadAllText(globalDataFile);
                    globalData = JsonSerializer.Deserialize<GlobalData>(jsonString) ?? new GlobalData();
                }
                else
                {
                    globalData = new GlobalData
                    {
                        HasKilledSans = false,
                        GlobalAchievements = new Dictionary<string, Achievement.AchievementData>()
                    };
                    SaveGlobalData();
                }
            }
            catch
            {
                globalData = new GlobalData();
                SaveGlobalData();
            }
        }

        public bool HasAnySaveFile() // 세이브 데이터 존재 확인 함수
        {
            bool isValidSaveFile(string filePath) // 각 세이브 파일이 존재하고 유효한지 검사
            {
                if (!File.Exists(filePath)) return false; // 파일이 없다면 false => 캐릭터 생성

                try
                {
                    string jsonString = File.ReadAllText(filePath); //세이브 데이터(json)의 텍스트를 읽어 문자열로 변환 => 세이브 내용을 jsonString에 저장
                    var saveData = JsonSerializer.Deserialize<GameData>(jsonString); //json 문자열 타입<GameData)를 객체로 변환 => saveData에 변수로 저장
                    return saveData?.Character != null; // 캐릭터 데이터가 있는지 확인
                }
                catch
                {
                    return false; //문자열 변환 이나 객체 변환 실패시 false 반환 => 캐릭터 슬롯 비어있는것으로 판단하여 캐릭터 생성
                }
            }

            // 세개의 슬롯 중 하나라도 세이브 데이터가 있다면 true 반환
            return isValidSaveFile(saveFile1) ||
                   isValidSaveFile(saveFile2) ||
                   isValidSaveFile(saveFile3);
        }

        private void DeleteSaveFile(string filePath) //세이브 데이터 삭제 함수
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath); // 세이브 데이터 삭제
                }
                catch (Exception ex) //세이브 데이터 삭제 오류 출력
                {
                    Console.WriteLine($"저장 파일 삭제 중 오류가 발생했습니다: {ex.Message}");
                    Thread.Sleep(5000);
                }
            }
        }
        public string GetCurrentSaveFile() // 지금 슬롯을 알려주는 함수
        {
            return currentSaveFile; // 지금 슬롯 정보를 반환
        }

        private bool CheckAnySansKilled()
        {
            return globalData.HasKilledSans;
        }
        public void UpdateGlobalAchievements(Dictionary<string, Achievement.AchievementData> achievements)
        {
            foreach (var achievement in achievements)
            {
                if (achievement.Value.IsUnlocked)
                {
                    if (!globalData.GlobalAchievements.ContainsKey(achievement.Key))
                    {
                        globalData.GlobalAchievements[achievement.Key] = achievement.Value;
                    }
                    else if (!globalData.GlobalAchievements[achievement.Key].IsUnlocked)
                    {
                        globalData.GlobalAchievements[achievement.Key] = achievement.Value;
                    }
                }
            }
            SaveGlobalData();
        }
        public Dictionary<string, Achievement.AchievementData> GetGlobalAchievements()
        {
            return globalData.GlobalAchievements;
        }

    }

}
