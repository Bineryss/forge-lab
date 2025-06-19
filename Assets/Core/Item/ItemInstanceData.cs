using UnityEngine;

namespace Core.Item
{
    [System.Serializable]
    public class ItemInstanceData : IInventoryItemDisplay
    {
        public string Id => data == null ? Item.Id : data.Id;
        public string Name => Item.Name;
        public string Description => Item.Description;
        public Sprite Icon => Item.Icon;
        public Rarity Rarity => Item.Rarity;
        public string StaticId => Item.Id;

        public Item Item;
        public IInstanceData data;
    }
}