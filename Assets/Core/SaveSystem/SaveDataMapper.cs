using System;
using System.Collections.Generic;
using Core.SaveSystem.Inventory;

namespace Core.SaveSystem
{
    public class SaveDataMapper
    {
        public static SaveFileContainer Convert(Dictionary<DataType, ISaveDataContainer> saveData)
        {

            saveData.TryGetValue(DataType.INVETORY, out ISaveDataContainer invetory);

            return new SaveFileContainer
            {
                Inventory = invetory is SInventorySaveDataContainer container ? container : default,
            };
        }

        public static Dictionary<DataType, ISaveDataContainer> Convert(SaveFileContainer data)
        {
            return new Dictionary<DataType, ISaveDataContainer>
            {
                {DataType.INVETORY, data.Inventory }
            };
        }
    }

    [Serializable]
    public struct SaveFileContainer
    {
        public SInventorySaveDataContainer Inventory;
    }
}