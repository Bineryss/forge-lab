using System;
using System.Collections.Generic;

namespace Core.SaveSystem.Inventory
{
    public class InventorySaveDataContainer : ISaveData
    {
        public ISaveDataContainer Data => data;
        public DataType Type => DataType.INVENTORY;

        private readonly InventoryDataContainer data;
        public InventorySaveDataContainer(InventoryDataContainer data)
        {
            this.data = data;
        }
    }

    [Serializable]
    public class InventoryDataContainer : ISaveDataContainer
    {
        public List<ItemResourceDataContainer> Resources;
        public List<ItemShipDataContainer> Ships;
    }
}