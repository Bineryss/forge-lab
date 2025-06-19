using Core.Item;

namespace Core.SaveSystem.Inventory
{
    [System.Serializable]
    public abstract class ItemDataContainer
    {
        public string Id;
        public string StaticId;
        public int Quantity;

    }
}