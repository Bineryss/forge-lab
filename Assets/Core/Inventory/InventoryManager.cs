using System.Collections.Generic;
using Core.Item;
using Core.SaveSystem;
using Core.SaveSystem.Inventory;
using UnityEngine;

namespace Core.Inventory
{
    public class InventoryManager : MonoBehaviour
    {

        private readonly ISaveSystem<Dictionary<ItemInstanceData, int>> saveSystem = InventorySaveSystem.Instance;

        private Dictionary<ItemInstanceData, int> inventory;

        public void Initialize()
        {
            inventory = saveSystem.Load();
        }

        public void ChangeQuantity(ItemInstanceData item, int quantity)
        {
            //TODO change quantity
            saveSystem.Save(inventory);
        }
    }
}