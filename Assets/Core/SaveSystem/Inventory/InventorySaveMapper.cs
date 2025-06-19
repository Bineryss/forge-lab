using System.Collections.Generic;
using System.Linq;
using Core.Item;

namespace Core.SaveSystem.Inventory
{
    public class InventorySaveMapper
    {
        public static SInventorySaveDataContainer Map(Dictionary<ItemInstanceData, int> resources, Dictionary<ItemInstanceData, int> ships)
        {
            return new SInventorySaveDataContainer
            {
                Resources = resources.Select(el => new ItemResourceDataContainer()
                {
                    Id = el.Key.Id,
                    StaticId = el.Key.StaticId,
                    Quantity = el.Value
                }).ToList(),
                Ships = ships.Select(el => new ItemShipDataContainer()
                {
                    Id = el.Key.Id,
                    StaticId = el.Key.StaticId,
                    Quantity = el.Value,
                    Effects = el.Key.data.Effects,
                    selectedWeaponId = el.Key.data is ShipInstanceData instance ? instance.EquipedWeaponId : ""
                }).ToList()
            };
        }
    }
}