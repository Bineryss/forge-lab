using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Item;
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


        [SerializeField] private List<ItemInstanceData> resources;
        [SerializeField] private List<ItemInstanceData> ships;
        [SerializeField] private SInventorySaveDataContainer loaded;
        [SerializeField] private ItemInstanceData converted;
        void Awake()
        {
            // testing only
            Dictionary<ItemInstanceData, int> resources = this.resources.ToDictionary(el => el, el => 10);
            this.ships[0].data = new ShipInstanceData(new List<Effect> { Effect.BUFF, Effect.NEUTRAL }, "weapon-0", "1234-5678"); ;
            this.ships[1].data = new ShipInstanceData(new List<Effect> { Effect.NEUTRAL }, "weapon-12", "6734-2342"); ;

            Dictionary<ItemInstanceData, int> ships = this.ships.ToDictionary(el => el, el => 1);
            SInventorySaveDataContainer container = InventorySaveMapper.Map(resources, ships);
            ISaveData testData = new InventorySaveDataContainer(container);
            SaveData(testData);

            saveData.Clear();
            LoadData();
            loaded = GetSaveData(DataType.INVETORY) is SInventorySaveDataContainer i ? i : default;
            Debug.Log($"loaded resources: {loaded.Resources[0]}, loaded ships {loaded.Ships[0]}");

            ItemShipDataContainer first = loaded.Ships[0];
            converted = new ItemInstanceData();
            converted.data = null;
            ItemRegistry.BuildIndex();
            converted.Item = ItemRegistry.Get(first.StaticId);
            ShipInstanceData instance = new ShipInstanceData(first.Effects, first.selectedWeaponId, first.Id);
            converted.data = instance;
            Debug.Log($"🚀 converted item instance data {converted.Id}-{converted.data.Effects}-{converted.data.Id}-{(converted.data as ShipInstanceData).EquipedWeaponId}");
        }
    }
}