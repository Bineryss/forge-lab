using Unity.Properties;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryItemDisplayData
    {
        [SerializeField, DontCreateProperty] private IInventoryItemDisplayData data;
        [CreateProperty] public Sprite Icon => data.Icon;
        [CreateProperty] public int Quantity => data.Quantity;
        [CreateProperty] public Sprite Background => data.Background;

        public InventoryItemDisplayData(IInventoryItemDisplayData data) => this.data = data;
    }
}
