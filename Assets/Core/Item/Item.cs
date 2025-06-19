using UnityEngine;

namespace Core.Item
{
    public abstract class InventoryItem : ScriptableObject, IInventoryItemDisplay
    {
        public string Id = System.Guid.NewGuid().ToString();

#if UNITY_EDITOR
        private void OnValidate()
        {
            // Generate a new ID only if missing
            if (string.IsNullOrEmpty(Id))
            {
                Id = System.Guid.NewGuid().ToString();
                UnityEditor.EditorUtility.SetDirty(this);
            }
        }
#endif

        [Header("Inventory")]
        public string Name;
        [TextArea]
        public string Description;
        public Sprite Icon;
        public Rarity Rarity;

        string IInventoryItemDisplay.Id => Id;
        string IInventoryItemDisplay.Name => Name;
        string IInventoryItemDisplay.Description => Description;
        public Sprite Sprite => Sprite;
        Rarity IInventoryItemDisplay.Rarity => Rarity;
    }
}