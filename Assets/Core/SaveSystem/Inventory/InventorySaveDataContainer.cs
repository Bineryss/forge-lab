using System;
using System.Collections.Generic;

namespace Core.SaveSystem.Inventory
{
    public class InventorySaveDataContainer : ISaveData
    {
        public ISaveDataContainer Data => data;
        public DataType Type => DataType.INVETORY;

        private SInventorySaveDataContainer data;
        public InventorySaveDataContainer(SInventorySaveDataContainer data)
        {
            this.data = data;
        }
    }

    [Serializable]
    public struct SInventorySaveDataContainer: ISaveDataContainer
    {
        public List<string> Resources;
        public List<string> Ships;
    }
}