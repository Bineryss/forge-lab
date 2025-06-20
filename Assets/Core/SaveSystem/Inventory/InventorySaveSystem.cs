using System.Collections.Generic;
using Core.Item;
using UnityEngine;

namespace Core.SaveSystem.Inventory
{
    public class InventorySaveSystem : ISaveSystem<Dictionary<ItemInstanceData, int>>
    {
        public static InventorySaveSystem Instance => instance ??= new InventorySaveSystem();
        private static InventorySaveSystem instance;


        private readonly SaveManager saveManager = SaveManager.Instance;
        private readonly IMapper<InventoryDataContainer, Dictionary<ItemInstanceData, int>> inventoryMapper = InventorySaveMapper.Instance;

        public void Save(Dictionary<ItemInstanceData, int> data)
        {
            InventoryDataContainer container = inventoryMapper.Map(data);
            ISaveData convertedData = new InventorySaveDataContainer(container);
            Debug.Log($"converted Data: {convertedData.Type}-{(convertedData.Data as InventoryDataContainer).Resources[0].Id}");
            saveManager.Save(convertedData);
        }

        public Dictionary<ItemInstanceData, int> Load()
        {
            InventoryDataContainer data = saveManager.GetSaveData(DataType.INVENTORY) as InventoryDataContainer;
            if (data == null)
            {
                return new();
            }

            return inventoryMapper.Map(data);
        }
    }
}