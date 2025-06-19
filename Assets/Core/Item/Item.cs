using System.Collections.Generic;
using UnityEngine;

namespace Core.Item
{
    public abstract class Item : ScriptableObject, IInventoryItemDisplay
    {
        [SerializeField] private string id = System.Guid.NewGuid().ToString();

        [Header("Inventory")]
        [SerializeField] private string itemName;
        [SerializeField, TextArea] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField] private Rarity rarity;
        [SerializeField] private List<Effect> effects;

        public abstract ItemType Type { get; }
        
        public string Id => id;
        public string Name => itemName;
        public string Description => description;
        public Sprite Icon => icon;
        public Rarity Rarity => rarity;


#if UNITY_EDITOR
        private void OnValidate()
        {
            // Generate a new ID only if missing
            if (string.IsNullOrEmpty(Id))
            {
                id = System.Guid.NewGuid().ToString();
                UnityEditor.EditorUtility.SetDirty(this);
            }
        }
#endif
    }
}