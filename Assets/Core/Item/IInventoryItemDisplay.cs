using UnityEngine;

namespace Core.Item
{
    public interface IInventoryItemDisplay
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Sprite Icon { get; }
        public Rarity Rarity { get; }
    }
}