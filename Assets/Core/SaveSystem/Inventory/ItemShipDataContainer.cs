using System.Collections.Generic;
using Core.Item;

namespace Core.SaveSystem.Inventory
{
    [System.Serializable]
    public class ItemShipDataContainer : ItemDataContainer
    {
        public List<Effect> Effects;
        public string selectedWeaponId;
    }
}