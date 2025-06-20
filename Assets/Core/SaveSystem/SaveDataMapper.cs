using System;
using System.Collections.Generic;
using Core.SaveSystem.Inventory;
using UnityEngine;


namespace Core.SaveSystem
{
    public class SaveDataMapper : IMapper<SaveFileContainer, Dictionary<DataType, ISaveDataContainer>>
    {
        public static SaveDataMapper Instance => instance ??= new SaveDataMapper();
        private static SaveDataMapper instance;


        public SaveFileContainer Map(Dictionary<DataType, ISaveDataContainer> saveData)
        {
            saveData.TryGetValue(DataType.INVENTORY, out ISaveDataContainer inventory);

            return new SaveFileContainer
            {
                Inventory = inventory as InventoryDataContainer,
            };
        }

        public Dictionary<DataType, ISaveDataContainer> Map(SaveFileContainer data)
        {
            return new Dictionary<DataType, ISaveDataContainer>
            {
                {DataType.INVENTORY, data.Inventory }
            };
        }
    }

    [Serializable]
    public struct SaveFileContainer
    {
        public InventoryDataContainer Inventory;
    }
}