using System.Collections.Generic;
using System.IO;
using Core.SaveSystem.Inventory;
using UnityEngine;

namespace Core.SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private string fileName;
        [SerializeField] private Dictionary<DataType, ISaveDataContainer> saveData = new();

        public void SaveData(ISaveData data)
        {
            saveData[data.Type] = data.Data;

            string saveDataJson = JsonUtility.ToJson(SaveDataMapper.Convert(saveData));
            Debug.Log($"saveDataJson: {saveDataJson}");
            File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), saveDataJson);
        }

        public void LoadData()
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);
            if (!File.Exists(path)) return;

            string jsonData = File.ReadAllText(path);
            SaveFileContainer saveData = JsonUtility.FromJson<SaveFileContainer>(jsonData);
            this.saveData = SaveDataMapper.Convert(saveData);
        }

        public ISaveDataContainer GetSaveData(DataType type)
        {
            saveData.TryGetValue(type, out ISaveDataContainer data);
            return data;
        }

        void Awake()
        {
            // testing only
            ISaveData testData = new InventorySaveDataContainer(
                new SInventorySaveDataContainer
                {
                    Resources = new() { "Carbonate", "Voidrium" },
                    Ships = new() { "alpha-1" }
                });
            SaveData(testData);

            saveData.Clear();
            LoadData();
            SInventorySaveDataContainer loadedInvetory = GetSaveData(DataType.INVETORY) is SInventorySaveDataContainer i ? i : default;
            Debug.Log($"loaded resources: {loadedInvetory.Resources[0]}, loaded ships {loadedInvetory.Ships[0]}");
        }
    }
}