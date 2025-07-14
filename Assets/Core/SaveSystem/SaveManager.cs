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

        public static SaveManager Instance { get; private set; }

        private readonly IMapper<SaveFileContainer, Dictionary<DataType, ISaveDataContainer>> saveDataMapper = SaveDataMapper.Instance;

        public void Save(ISaveData data)
        {
            saveData[data.Type] = data.Data;

            string saveDataJson = JsonUtility.ToJson(saveDataMapper.Map(saveData));
            Debug.Log($"📃 saveDataJson: {saveDataJson}");
            File.WriteAllText(Path.Combine(Application.persistentDataPath, fileName), saveDataJson);
        }

        public void Load()
        {
            string path = Path.Combine(Application.persistentDataPath, fileName);
            if (!File.Exists(path)) return;

            string jsonData = File.ReadAllText(path);
            SaveFileContainer saveData = JsonUtility.FromJson<SaveFileContainer>(jsonData);
            this.saveData = saveDataMapper.Map(saveData);
        }

        public ISaveDataContainer GetSaveData(DataType type)
        {
            saveData.TryGetValue(type, out ISaveDataContainer data);
            return data;
        }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Load();
            InvetorySaveSystemTesting();
        }



        // testing
        [SerializeField] private List<ItemInstanceData> resources;
        [SerializeField] private List<ItemInstanceData> ships;
        [SerializeField] private InventoryDataContainer loaded;
        [SerializeField] private ItemInstanceData converted;

        //InvetorySaveMapper testing
        private void InvetorySaveSystemTesting()
        {
            Dictionary<ItemInstanceData, int> resources = this.resources.ToDictionary(el => el, el => 69);
            this.ships[0].data = new ShipInstanceData(new List<Effect> { Effect.BUFF, Effect.NEUTRAL }, "weapon-0", "1234-5678"); ;
            this.ships[1].data = new ShipInstanceData(new List<Effect> { Effect.NEUTRAL }, "weapon-12", "6734-2342"); ;

            Dictionary<ItemInstanceData, int> ships = this.ships.ToDictionary(el => el, el => 1);
            Dictionary<ItemInstanceData, int> inventoryData = resources.Concat(ships).ToDictionary(pair => pair.Key, pair => pair.Value);


            InventorySaveSystem.Instance.Save(inventoryData);


            // loading setup, will be done centralized and somewhere else
            saveData.Clear();
            Load();
            //

            var inventory = InventorySaveSystem.Instance.Load();

            Debug.Log($"💻 Inventory data: {string.Join(", ", inventory.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");

            loaded = GetSaveData(DataType.INVENTORY) is InventoryDataContainer i ? i : default;
            ItemShipDataContainer first = loaded.Ships[0];
            converted = new ItemInstanceData
            {
                data = new ShipInstanceData(first.Effects, first.selectedWeaponId, first.Id),
                Item = ItemRegistry.Instance.Get(first.StaticId),
            };
            Debug.Log($"🚀 converted item instance data {converted.Id}-{converted.data.Effects}-{converted.data.Id}-{(converted.data as ShipInstanceData).EquipedWeaponId}");

        }
    }
}